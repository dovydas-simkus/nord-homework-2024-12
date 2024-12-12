using MediatR;
using PartyCli.Domain.Models;
using PartyCli.Persistence;
using PartyCli.Services.CliCommandOptions;
using PartyCli.Services.Mappers;
using PartyCli.Services.Output;
using PartyCli.Services.Providers;

namespace PartyCli.Services.Commands
{
    /// <summary>
    /// Handles the execution of the server list command.
    /// </summary>
    internal sealed class ExecuteServerListCommandHandler : IRequestHandler<ExecuteServerListCommand>
    {
        private readonly IServerProviderFactory _serverProviderFactory;
        private readonly IServerRepository _serverRepository;
        private readonly ICommandOptionsToQueryMapper _commandOptionsToQueryMapper;
        private readonly IConsoleOutputServiceFactory _consoleOutputServiceFactory;

        public ExecuteServerListCommandHandler(
            IServerProviderFactory serverProviderFactory,
            IServerRepository serverRepository,
            ICommandOptionsToQueryMapper commandOptionsToQueryMapper,
            IConsoleOutputServiceFactory consoleOutputServiceFactory
        )
        {
            _serverProviderFactory = serverProviderFactory;
            _serverRepository = serverRepository;
            _commandOptionsToQueryMapper = commandOptionsToQueryMapper;
            _consoleOutputServiceFactory = consoleOutputServiceFactory;
        }

        /// <summary>
        /// Handles the server list command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Handle(ExecuteServerListCommand command, CancellationToken cancellationToken)
        {
            ValidateCommandOptions(command.Options);

            var servers = GetServersAsync(command.Options, cancellationToken);

            servers = ConsoleOutput(command.Options, servers);

            await StoreServersAsync(command.Options, servers, cancellationToken);
        }

        private void ValidateCommandOptions(ServerListOptions options)
        {
            if (options.OutputFormat is { } outputFormat)
            {
                if (outputFormat is ServerListOptions.SupportedOutputFormats.Json
                    or ServerListOptions.SupportedOutputFormats.Tsv
                    or ServerListOptions.SupportedOutputFormats.Pretty
                )
                {
                    return;
                }

                throw new InvalidCommandOptionsException(
                    $"Invalid output format specified: {outputFormat}. Valid values are 'json', 'tsv', and 'pretty'.");
            }
        }

        private IAsyncEnumerable<Server> GetServersAsync(ServerListOptions options, CancellationToken cancellationToken)
        {
            var query = _commandOptionsToQueryMapper.Map(options);

            var serverProvider = GetServerProvider(options);

            var servers = serverProvider.GetAsync(query, cancellationToken);

            return servers;
        }

        private IServerProvider GetServerProvider(ServerListOptions options)
        {
            var serverProvider = _serverProviderFactory.NordVpnApi();

            if (options.FetchLocal)
            {
                serverProvider = _serverProviderFactory.PersistentStore();
            }

            return serverProvider;
        }

        private IAsyncEnumerable<Server> ConsoleOutput(ServerListOptions commandOptions, IAsyncEnumerable<Server> servers)
        {
            var consoleOutputService = _consoleOutputServiceFactory.GetConsoleOutputService(commandOptions.OutputFormat ?? ServerListOptions.SupportedOutputFormats.Default);

            return consoleOutputService.OutputAsync(servers);
        }

        private async ValueTask StoreServersAsync(
            ServerListOptions options,
            IAsyncEnumerable<Server> servers,
            CancellationToken cancellationToken
        )
        {
            if (options.FetchLocal)
            {
                await servers.ToListAsync(cancellationToken);

                return;
            }

            await _serverRepository.UpsertAsync(servers, cancellationToken);
        }
    }
}
