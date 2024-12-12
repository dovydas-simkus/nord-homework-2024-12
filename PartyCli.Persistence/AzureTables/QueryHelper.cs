using PartyCli.Domain.Querying;
using PartyCli.Domain.Querying.Filtering;
using PartyCli.Persistence.AzureTables.Querying;
using ComplexFilter = PartyCli.Persistence.AzureTables.Querying.ComplexFilter;
using SimpleFilter = PartyCli.Persistence.AzureTables.Querying.SimpleFilter;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Provides helper methods for converting domain queries to Azure Table queries.
    /// </summary>
    internal static class QueryHelper
    {
        /// <summary>
        /// Converts a domain query to an Azure Table query.
        /// </summary>
        /// <param name="query">The domain query to convert.</param>
        /// <returns>An <see cref="AzureTablesQuery"/> representing the converted query.</returns>
        public static AzureTablesQuery ToAzureTablesQuery(this IQuery query)
        {
            IFilter? filter = null;

            if (query.Filter is Domain.Querying.Filtering.ComplexFilter complexFilter)
            {
                filter = ComplexFilter.FromDomainFilter(complexFilter);
            }
            else if (query.Filter is Domain.Querying.Filtering.SimpleFilter simpleFilter)
            {
                filter = SimpleFilter.FromDomainFilter(simpleFilter);
            }

            return new AzureTablesQuery(filter);
        }
    }
}
