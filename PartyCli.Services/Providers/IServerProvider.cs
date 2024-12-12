using PartyCli.Domain.Models;
using PartyCli.Domain.Querying;

namespace PartyCli.Services.Providers
{
    /// <summary>
    /// Defines the interface for server providers.
    /// </summary>
    public interface IServerProvider
    {
        /// <summary>
        /// Retrieves the servers asynchronously based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the servers.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>An asynchronous enumerable of servers.</returns>
        IAsyncEnumerable<Server> GetAsync(IQuery? query, CancellationToken cancellationToken = default);
    }
}
