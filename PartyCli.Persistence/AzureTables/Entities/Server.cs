using System.Text.Json;
using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Persistence.AzureTables.Entities;

internal sealed record Server : TableEntity
{
    public Server()
    {
    }

    public Server(Domain.Models.Server model) : base(GetPartitionKey(), GetRowKey(model.Id))
    {
        Id = model.Id;
        Name = model.Name;
        Load = model.Load;
        Status = model.Status;
        VpnProtocols = JsonSerializer.Serialize(model.VpnProtocols.Select(x => x.ToString()));
        Country = model.Country.ToString();
    }

    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public int Load { get; init; }
    public string Status { get; init; } = null!;
    public string VpnProtocols { get; set; }
    public string Country { get; init; }

    public static string GetPartitionKey() => "Server";
    public static string GetRowKey(int id) => $"Id:{id}";

    public static Querying.ComplexFilter GetFilterForGetMany()
    {
        var partitionKeyFilter = new Querying.SimpleFilter(nameof(PartitionKey), ComparisonOperator.Equal, GetPartitionKey());
        var rowKeyStartFilter = new Querying.SimpleFilter(nameof(RowKey), ComparisonOperator.GreaterThan, "Id:");
        var rowKeyFilter = new Querying.SimpleFilter(nameof(RowKey), ComparisonOperator.LowerThan, "Id;");

        return new Querying.ComplexFilter([partitionKeyFilter, rowKeyStartFilter, rowKeyFilter], LogicalOperator.And);
    }

    public Domain.Models.Server ToModel()
    {
        var vpnProtocols = JsonSerializer.Deserialize<string[]>(VpnProtocols) ?? [];

        return new Domain.Models.Server(Id, Name, Load, Status, vpnProtocols.Select(x => Enum.Parse<VpnProtocol>(x)).ToArray(),
            Enum.Parse<Country>(Country));
    }
}
