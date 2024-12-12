namespace PartyCli.Domain.Querying.Filtering
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class SupportsFilter : Attribute
    {
        public SupportsFilter(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
