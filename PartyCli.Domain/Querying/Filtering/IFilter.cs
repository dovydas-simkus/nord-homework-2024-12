namespace PartyCli.Domain.Querying.Filtering
{
    /// <summary>
    /// Represents a filter that can be combined with other filters and built into a query string.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Combines the current filter with a simple filter using a logical AND operator.
        /// </summary>
        /// <param name="filter">The simple filter to combine with.</param>
        /// <returns>A new complex filter representing the combination.</returns>
        public IComplexFilter And(ISimpleFilter filter);

        /// <summary>
        /// Combines the current filter with another complex filter using a logical AND operator.
        /// </summary>
        /// <param name="filter">The complex filter to combine with.</param>
        /// <returns>A new complex filter representing the combination.</returns>
        public IComplexFilter And(IComplexFilter filter);

        /// <summary>
        /// Builds the query string based on the filter.
        /// </summary>
        /// <returns>The query string.</returns>
        string Build();
    }
}
