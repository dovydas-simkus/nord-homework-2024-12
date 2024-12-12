using Azure.Data.Tables;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Defines the interface for a table client.
    /// </summary>
    internal interface ITableClient
    {
        /// <summary>
        /// Upserts the specified entities asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities to upsert.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpsertAsync<TEntity>(IAsyncEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : ITableEntity, new();

        /// <summary>
        /// Retrieves the entities asynchronously based on the specified filter.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="filter">The filter to apply to the query.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>An asynchronous enumerable of entities.</returns>
        IAsyncEnumerable<TEntity> GetAsync<TEntity>(string? filter = null, CancellationToken cancellationToken = default) where TEntity : class, ITableEntity, new();
    }
}
