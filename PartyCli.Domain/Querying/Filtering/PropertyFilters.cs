using System.Reflection;

namespace PartyCli.Domain.Querying.Filtering
{
    public static class PropertyFilters
    {
        public static IPropertyFilter Country { get; } = new PropertyFilter("Country");
        public static IPropertyFilter VpnProtocol { get; } = new PropertyFilter("VpnProtocol");

        public static bool IsSupportedBy(this IPropertyFilter propertyFilter, Type type)
        {
            var attributes = (SupportsFilter[])type.GetCustomAttributes(typeof(SupportsFilter));

            if (!attributes.Any())
            {
                throw new ArgumentException($"The type '{type.FullName}' filtering. Try decorating type with '{nameof(SupportsFilter)}'.");
            }

            if (attributes.FirstOrDefault(x => x.Name == propertyFilter.Name) == null)
            {
                throw new ArgumentException($"The type '{type.FullName}' does not support '{propertyFilter.Name}' filter.");
            }

            return true;
        }
    }
}
