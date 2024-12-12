namespace PartyCli.Domain.Querying.Filtering
{
    /// <inheritdoc/>
    public class SimpleFilter : ISimpleFilter
    {
        public SimpleFilter(string name, ComparisonOperator comparisonOperator, object value)
        {
            Name = name;
            ComparisonOperator = comparisonOperator;
            Value = value;
        }

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public ComparisonOperator ComparisonOperator { get; }

        /// <inheritdoc/>
        public object Value { get; }

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
            return $"{Name} {ComparisonOperator} {Value}";
        }
    }
}
