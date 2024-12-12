namespace PartyCli.Domain.Querying.Filtering
{
    /// <inheritdoc/>
    public class ComplexFilter : IComplexFilter
    {
        public ComplexFilter(IEnumerable<IFilter> filters, LogicalOperator logicalOperator)
        {
            Filters = filters;
            LogicalOperator = logicalOperator;
        }

        /// <inheritdoc/>
        public IEnumerable<IFilter> Filters { get; }

        /// <inheritdoc/>
        public LogicalOperator LogicalOperator { get; }

        /// <inheritdoc/>
        public virtual IComplexFilter And(ISimpleFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public virtual IComplexFilter And(IComplexFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public virtual string Build()
        {
            string logicalOperatorString;

            switch (LogicalOperator)
            {
                case LogicalOperator.And:
                    logicalOperatorString = " AND ";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(LogicalOperator), LogicalOperator, null);
            }

            var filterStrings = Filters.Select(f => f.Build());

            return string.Join(logicalOperatorString, filterStrings);
        }
    }
}
