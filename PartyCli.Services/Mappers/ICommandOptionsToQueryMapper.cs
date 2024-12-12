using PartyCli.Domain.Querying;
using PartyCli.Services.CliCommandOptions;

namespace PartyCli.Services.Mappers
{
    /// <summary>
    /// Defines a mapper that converts command options to queries.
    /// </summary>
    public interface ICommandOptionsToQueryMapper
    {
        /// <summary>
        /// Maps the specified command options to a query.
        /// </summary>
        /// <param name="options">The command options to map.</param>
        /// <returns>The query corresponding to the command options, or null if the options cannot be mapped.</returns>
        IQuery? Map(ICommandOptions options);
    }
}
