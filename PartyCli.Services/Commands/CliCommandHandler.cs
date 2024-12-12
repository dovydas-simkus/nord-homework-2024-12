using MediatR;
using PartyCli.Services.CliCommandOptions;

namespace PartyCli.Services.Commands
{
    /// <summary>
    /// Handles CLI commands by parsing arguments and executing the appropriate command.
    /// </summary>
    internal sealed class CliCommandHandler : IRequestHandler<CliCommand, int>
    {
        private readonly IMediator _mediator;

        public CliCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the specified CLI command.
        /// </summary>
        /// <param name="command">The CLI command to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the status code.</returns>
        public async Task<int> Handle(CliCommand command, CancellationToken cancellationToken)
        {
            var parsedOptions = CommandLine.Parser.Default.ParseArguments<ServerListOptions>(command.Args);

            if (parsedOptions.Errors.Any())
            {
                return 1;
            }

            try
            {
                await _mediator.Send(new ExecuteServerListCommand(parsedOptions.Value), cancellationToken);

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"'{parsedOptions.Value}' failed: {e.Message}{Environment.NewLine}{e.StackTrace}");

                return 1;
            }
        }
    }
}
