using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.NordVpnClient.Querying
{
    /// <inheritdoc/>
    internal sealed class ComplexFilter : Domain.Querying.Filtering.ComplexFilter
    {
        public ComplexFilter(IEnumerable<IFilter> filters, LogicalOperator logicalOperator) : base(filters, logicalOperator)
        {
        }

        /// <inheritdoc/>
        public override string Build()
        {
            string logicalOperatorString;

            switch (LogicalOperator)
            {
                case LogicalOperator.And:
                    logicalOperatorString = "&";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(LogicalOperator), LogicalOperator, null);
            }

            var filterStrings = Filters.Select(f => f.Build());

            return string.Join(logicalOperatorString, filterStrings);
        }

        public static ComplexFilter FromDomainFilter(Domain.Querying.Filtering.ComplexFilter filter)
        {
            var filters = new List<IFilter>();

            foreach (var inner in filter.Filters)
            {
                if (inner is Domain.Querying.Filtering.ComplexFilter innerComplexFilter)
                {
                    filters.Add(FromDomainFilter(innerComplexFilter));
                }
                else if (inner is Domain.Querying.Filtering.SimpleFilter innerSimpleFilter)
                {
                    filters.Add(SimpleFilter.FromDomainFilter(innerSimpleFilter));
                }
            }

            return new ComplexFilter(filters, filter.LogicalOperator);
        }
    }
}
