using PartyCli.Domain.Models;
using PartyCli.Domain.Querying;

namespace PartyCli.Persistence
{
    /// <summary>
    /// Defines the interface for a server repository.
    /// </summary>
    public interface IServerRepository
    {
        /// <summary>
        /// Upserts the specified servers asynchronously.
        /// </summary>
        /// <param name="servers">The servers to upsert.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpsertAsync(IAsyncEnumerable<Server> servers, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the servers asynchronously based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the servers.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>An asynchronous enumerable of servers.</returns>
        IAsyncEnumerable<Server> GetAsync(IQuery? query = null, CancellationToken cancellationToken = default);
    }
}
