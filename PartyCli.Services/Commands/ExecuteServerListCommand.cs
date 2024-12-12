using MediatR;
using PartyCli.Services.CliCommandOptions;

namespace PartyCli.Services.Commands
{
    /// <summary>
    /// Represents a command to execute the server_list operation.
    /// </summary>
    public sealed class ExecuteServerListCommand : IRequest
    {
        public ExecuteServerListCommand(ServerListOptions options)
        {
            Options = options;
        }

        /// <summary>
        /// Options for the server list command.
        /// </summary>
        public ServerListOptions Options { get; }
    }
}
