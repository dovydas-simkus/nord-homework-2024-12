namespace PartyCli.Domain.Querying.Filtering
{
    /// <summary>
    /// Represents a filter based on a property.
    /// </summary>
    public interface IPropertyFilter
    {
        /// <summary>
        /// Gets the name of the property to filter on.
        /// </summary>
        public string Name { get; }
    }
}
