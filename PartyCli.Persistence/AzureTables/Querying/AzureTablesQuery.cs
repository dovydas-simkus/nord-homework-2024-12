using PartyCli.Domain.Querying;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Persistence.AzureTables.Querying
{
    /// <summary>
    /// Represents a query for Azure Tables.
    /// </summary>
    internal sealed class AzureTablesQuery : IQuery
    {
        public AzureTablesQuery(IFilter? filter = null)
        {
            Filter = filter;
        }

        /// <inheritdoc/>
        public IFilter? Filter { get; }

        /// <inheritdoc/>
        public string Build()
        {
            var filterString = Filter?.Build() ?? string.Empty;

            return filterString;
        }
    }
}
