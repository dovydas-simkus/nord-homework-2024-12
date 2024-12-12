namespace PartyCli.Domain.Querying.Filtering
{
    /// <inheritdoc />
    public sealed class PropertyFilter : IPropertyFilter
    {
        public PropertyFilter(string name)
        {
            Name = name;
        }

        /// <inheritdoc />
        public string Name { get; }
    }
}
