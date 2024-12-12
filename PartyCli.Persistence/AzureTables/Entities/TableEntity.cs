using Azure;
using Azure.Data.Tables;

namespace PartyCli.Persistence.AzureTables.Entities;

/// <summary>
/// Represents an abstract base class for table entities.
/// </summary>
internal abstract record TableEntity : ITableEntity
{
#pragma warning disable CS8618, CS9264
    protected TableEntity()
#pragma warning restore CS8618, CS9264
    {
    }

    protected TableEntity(string partitionKey, string rowKey)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
    }

    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}
