namespace PartyCli.Domain.Querying.Filtering
{
    /// <summary>
    /// Represents a complex filter that combines multiple filters using a logical operator.
    /// </summary>
    public interface IComplexFilter : IFilter
    {
        /// <summary>
        /// Gets the collection of filters that are combined by this complex filter.
        /// </summary>
        IEnumerable<IFilter> Filters { get; }

        /// <summary>
        /// Gets the logical operator used to combine the filters.
        /// </summary>
        LogicalOperator LogicalOperator { get; }
    }
}
