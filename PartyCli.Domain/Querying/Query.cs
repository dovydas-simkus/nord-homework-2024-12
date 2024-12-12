using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Domain.Querying
{
    /// <inheritdoc/>
    public sealed class Query : IQuery
    {
        public Query(IFilter? filter = null)
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
