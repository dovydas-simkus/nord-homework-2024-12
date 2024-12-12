using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Provides a client for interacting with Azure Table storage.
    /// </summary>
    internal sealed class TableClient : ITableClient
    {
        private readonly Azure.Data.Tables.TableClient _tableClient;

        public TableClient(Azure.Data.Tables.TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        /// <inheritdoc/>
        public async Task UpsertAsync<TEntity>(IAsyncEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : ITableEntity, new()
        {
            var transactionActions = new List<TableTransactionAction>();

            await foreach (var entity in entities.WithCancellation(cancellationToken))
            {
                transactionActions.Add(new TableTransactionAction(TableTransactionActionType.UpsertReplace, entity));

                if (transactionActions.Count == 100)
                {
                    await SubmitTransactionAsync(transactionActions, cancellationToken);

                    transactionActions.Clear();
                }
            }

            if (transactionActions.Any())
            {
                await SubmitTransactionAsync(transactionActions, cancellationToken);
            }
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<TEntity> GetAsync<TEntity>(string? filter = null, CancellationToken cancellationToken = default) where TEntity : class, ITableEntity, new()
        {
            try
            {
                return _tableClient.QueryAsync<TEntity>(filter, 1000, cancellationToken: cancellationToken);
            }
            catch (RequestFailedException e) when (e.ErrorCode == TableErrorCode.TableNotFound)
            {
                return Array.Empty<TEntity>().ToAsyncEnumerable();
            }
        }

        private async Task SubmitTransactionAsync(List<TableTransactionAction> transactionActions, CancellationToken cancellationToken = default)
        {
            try
            {
                await _tableClient.SubmitTransactionAsync(transactionActions, cancellationToken);
            }
            catch (RequestFailedException e) when (e.ErrorCode == TableErrorCode.TableNotFound)
            {
                await _tableClient.CreateIfNotExistsAsync(cancellationToken);

                // Need to repeat operation because table did not exist before.
                await _tableClient.SubmitTransactionAsync(transactionActions, cancellationToken);
            }
        }
    }
}
