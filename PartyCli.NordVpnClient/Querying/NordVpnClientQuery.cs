using PartyCli.Domain.Querying;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.NordVpnClient.Querying
{
    /// <summary>
    /// Represents a query for the NordVPN client.
    /// </summary>
    internal sealed class NordVpnClientQuery : IQuery
    {
        public NordVpnClientQuery(IFilter? filter = null)
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
