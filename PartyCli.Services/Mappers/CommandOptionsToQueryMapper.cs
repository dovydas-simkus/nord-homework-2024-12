using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Models;
using PartyCli.Domain.Querying;
using PartyCli.Domain.Querying.Filtering;
using PartyCli.Services.CliCommandOptions;

namespace PartyCli.Services.Mappers
{
    /// <summary>
    /// Maps command options to queries.
    /// </summary>
    internal sealed class CommandOptionsToQueryMapper : ICommandOptionsToQueryMapper
    {
        /// <inheritdoc />
        public IQuery? Map(ICommandOptions options)
        {
            if (options is ServerListOptions serverListOptions)
            {
                var filters = new List<IFilter>();
                var modelType = typeof(Server);

                if (serverListOptions.FilterByFrance)
                {
                    var countryFilter = PropertyFilters.Country;

                    if (countryFilter.IsSupportedBy(modelType))
                    {
                        filters.Add(new SimpleFilter(countryFilter.Name, ComparisonOperator.Equal, Country.France));
                    }
                }

                if (serverListOptions.FilterByTcp)
                {
                    var vpnProtocolFilter = PropertyFilters.VpnProtocol;

                    if (vpnProtocolFilter.IsSupportedBy(modelType))
                    {
                        filters.Add(new SimpleFilter(vpnProtocolFilter.Name, ComparisonOperator.Equal, VpnProtocol.Tcp));
                    }
                }

                IQuery? query = null;

                if (filters.Any())
                {
                    query = new Query(new ComplexFilter(filters, LogicalOperator.And));
                }

                return query;
            }

            return null;
        }
    }
}
