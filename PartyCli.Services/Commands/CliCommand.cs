using MediatR;

namespace PartyCli.Services.Commands
{
    /// <summary>
    /// Represents a command to be executed by the CLI.
    /// </summary>
    public class CliCommand : IRequest<int>
    {
        public CliCommand(string[] args)
        {
            Args = args;
        }

        /// <summary>
        /// Gets the arguments for the CLI command.
        /// </summary>
        public string[] Args { get; }
    }
}
