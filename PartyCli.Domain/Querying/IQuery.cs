using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Domain.Querying
{
    /// <summary>
    /// Represents a query.
    /// </summary>
    public interface IQuery
    {
        /// <summary>
        /// The filter applied to the query.
        /// </summary>
        IFilter? Filter { get; }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <returns>The query string.</returns>
        string Build();
    }
}
