using PartyCli.Domain.Querying;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.NordVpnClient.Querying
{
    /// <summary>
    /// Provides helper methods for converting queries to NordVPN client queries.
    /// </summary>
    internal static class QueryHelper
    {
        /// <summary>
        /// Converts a domain query to a NordVPN client query.
        /// </summary>
        /// <param name="query">The domain query to convert.</param>
        /// <returns>A <see cref="NordVpnClientQuery"/> representing the converted query.</returns>
        public static NordVpnClientQuery ToNordVpnClientQuery(this IQuery query)
        {
            IFilter? nordVpnClientFilter = null;

            if (query.Filter is Domain.Querying.Filtering.ComplexFilter complexFilter)
            {
                nordVpnClientFilter = ComplexFilter.FromDomainFilter(complexFilter);
            }
            else if (query.Filter is Domain.Querying.Filtering.SimpleFilter simpleFilter)
            {
                nordVpnClientFilter = SimpleFilter.FromDomainFilter(simpleFilter);
            }

            return new NordVpnClientQuery(nordVpnClientFilter);
        }
    }
}
