using Microsoft.Extensions.Options;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Provides a client for accessing Azure Table storage.
    /// </summary>
    internal sealed class TableClientProvider : ITableClientProvider
    {
        private readonly AzureStorageOptions _options;

        public TableClientProvider(IOptions<AzureStorageOptions> options)
        {
            _options = options.Value;
        }

        /// <inheritdoc/>
        public ITableClient Get(string tableName) => new TableClient(new Azure.Data.Tables.TableClient(_options.ConnectionString, tableName));
    }
}
