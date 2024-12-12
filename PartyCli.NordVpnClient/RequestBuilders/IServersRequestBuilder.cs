using PartyCli.Domain.Querying;
using PartyCli.NordVpnClient.Models;

namespace PartyCli.NordVpnClient.RequestBuilders
{
    /// <summary>
    /// Defines the interface for building requests to the servers endpoint.
    /// </summary>
    public interface IServersRequestBuilder
    {
        /// <summary>
        /// Asynchronously gets a collection of servers based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the servers.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>An asynchronous enumerable of servers.</returns>
        IAsyncEnumerable<Server> GetAsync(IQuery? query, CancellationToken cancellationToken = default);
    }
}
