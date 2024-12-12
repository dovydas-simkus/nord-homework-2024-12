using System.Text.Json.Serialization;

namespace PartyCli.Services.Output.Models;

internal sealed partial record Server
{
    private Server(string name, int load, string status)
    {
        Name = name;
        Load = load;
        Status = status;
    }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("load")]
    public int Load { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    public static Server FromDomainModel(Domain.Models.Server server)
    {
        return new Server(server.Name, server.Load, server.Status);
    }
}
