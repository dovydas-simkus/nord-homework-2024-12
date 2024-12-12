using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Persistence.AzureTables.Querying
{
    /// <summary>
    /// Represents a complex filter for Azure Tables queries.
    /// </summary>
    internal sealed class ComplexFilter : Domain.Querying.Filtering.ComplexFilter
    {
        public ComplexFilter(IEnumerable<IFilter> filters, LogicalOperator logicalOperator) : base(filters, logicalOperator)
        {
        }

        /// <inheritdoc/>
        public override IComplexFilter And(ISimpleFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public override IComplexFilter And(IComplexFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public override string Build()
        {
            string logicalOperatorString;

            switch (LogicalOperator)
            {
                case LogicalOperator.And:
                    logicalOperatorString = " and ";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(LogicalOperator), LogicalOperator, "Unsupported logical operator");
            }

            var filterStrings = Filters.Select(f => f.Build());

            return string.Join(logicalOperatorString, filterStrings);
        }

        /// <summary>
        /// Creates a new <see cref="ComplexFilter"/> from a domain complex filter.
        /// </summary>
        /// <param name="filter">The domain complex filter to convert.</param>
        /// <returns>A new complex filter.</returns>
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
