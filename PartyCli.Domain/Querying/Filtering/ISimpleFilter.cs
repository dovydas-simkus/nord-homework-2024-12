namespace PartyCli.Domain.Querying.Filtering
{
    /// <summary>
    /// Represents a simple filter.
    /// </summary>
    public interface ISimpleFilter : IFilter
    {
        /// <summary>
        /// Gets the name of the filter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the comparison operator used in the filter.
        /// </summary>
        public ComparisonOperator ComparisonOperator { get; }

        /// <summary>
        /// Gets the value to be compared in the filter.
        /// </summary>
        public object Value { get; }
    }
}
