using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.NordVpnClient.Querying
{
    /// <inheritdoc/>
    internal sealed class SimpleFilter : Domain.Querying.Filtering.SimpleFilter
    {
        public SimpleFilter(string name, ComparisonOperator comparisonOperator, object value) : base(name, comparisonOperator, value)
        {
        }

        /// <inheritdoc/>
        public override IComplexFilter And(ISimpleFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public override IComplexFilter And(IComplexFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc/>
        public override string Build()
        {
            var name = GetClientSpecificFilterName(Name);
            var value = GetClientSpecificFilterValue(Name, Value);

            return $"filters{name}{Map(ComparisonOperator)}{value}";
        }

        public static SimpleFilter FromDomainFilter(Domain.Querying.Filtering.SimpleFilter filter)
        {
            return new SimpleFilter(filter.Name, filter.ComparisonOperator, filter.Value);
        }

        private static string GetClientSpecificFilterValue(string filterName, object value)
        {
            if (value is Enum)
            {
                if (filterName == PropertyFilters.VpnProtocol.Name)
                {
                    return MapVpnProtocol((VpnProtocol)value);
                }

                if (filterName == PropertyFilters.Country.Name)
                {
                    return MapCountry((Domain.Classifiers.Country)value);
                }
            }

            if (value is string stringValue)
            {
                return stringValue;
            }

            throw new ArgumentException($"Value of type '{value.GetType()}' is not supported for filter '{filterName}'.");
        }

        private static string MapVpnProtocol(VpnProtocol value)
        {
            switch (value)
            {
                case VpnProtocol.Tcp:
                    return "5";
                default:
                    throw new ArgumentException($"Unsupported vpn protocol '{value}'.");
            }
        }

        private static string MapCountry(Domain.Classifiers.Country value)
        {
            switch (value)
            {
                case Domain.Classifiers.Country.France:
                    return "74";
                default:
                    throw new ArgumentException($"Unsupported country '{value}'.");
            }
        }

        private static string GetClientSpecificFilterName(string name)
        {
            if (name == PropertyFilters.VpnProtocol.Name)
            {
                return "[servers_technologies][id]";
            }

            if (name == PropertyFilters.Country.Name)
            {
                return "[country_id]";
            }

            throw new ArgumentException($"Unsupported filter: {name}.");
        }

        private static string Map(ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return "=";
                case ComparisonOperator.NotEqual:
                    return "!=";
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator), comparisonOperator, null);
            }
        }
    }
}
