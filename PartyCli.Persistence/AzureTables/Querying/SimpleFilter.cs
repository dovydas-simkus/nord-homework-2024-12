using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Persistence.AzureTables.Querying
{
    /// <summary>
    /// Represents a simple filter for Azure Tables queries.
    /// </summary>
    internal sealed class SimpleFilter : Domain.Querying.Filtering.SimpleFilter
    {
        public SimpleFilter(string name, ComparisonOperator comparisonOperator, object value) : base(name, comparisonOperator, value)
        {
        }

        /// <inheritdoc />
        public override IComplexFilter And(ISimpleFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc />
        public override IComplexFilter And(IComplexFilter filter)
        {
            return new ComplexFilter([this, filter], LogicalOperator.And);
        }

        /// <inheritdoc />
        public override string Build()
        {
            var name = GetAzureTablesSpecificFilterName(Name);
            var value = GetAzureTablesSpecificFilterValue(Name, Value);

            return $"{name} {Map(ComparisonOperator)} {value}";
        }

        public static SimpleFilter FromDomainFilter(Domain.Querying.Filtering.SimpleFilter filter)
        {
            return new SimpleFilter(filter.Name, filter.ComparisonOperator, filter.Value);
        }



        private string GetAzureTablesSpecificFilterValue(string filterName, object value)
        {
            if (value is Enum)
            {
                // if (name == PropertyFilters.VpnProtocol.Name)
                // {
                //     return MapVpnProtocol((VpnProtocol)value);
                // }
                //
                if (filterName == PropertyFilters.Country.Name)
                {
                    return$"'{(Country)value}'";
                }
            }

            if (value is string stringValue)
            {
                return $"'{stringValue}'";
            }

            if (value is int)
            {
                return value.ToString();
            }

            throw new ArgumentException($"Value of type '{value.GetType()}' is not supported for filter '{filterName}'.");
        }

        private string Map(ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return "eq";
                case ComparisonOperator.NotEqual:
                    return "ne";
                case ComparisonOperator.LowerThan:
                    return "lt";
                case ComparisonOperator.GreaterThan:
                    return "gt";
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator), comparisonOperator, "Comparison operator is not supported.");
            }
        }

        private string GetAzureTablesSpecificFilterName(string name)
        {
            if (name == PropertyFilters.Country.Name)
            {
                return "Country";
            }

            if (name == PropertyFilters.VpnProtocol.Name)
            {
                return "VpnProtocols";
            }

            if (name == "PartitionKey" || name == "RowKey")
            {
                return name;
            }

            throw new ArgumentException("Filter name is not supported.");
        }
    }
}
