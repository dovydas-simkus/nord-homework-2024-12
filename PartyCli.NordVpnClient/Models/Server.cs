namespace PartyCli.NordVpnClient.Models;

public sealed record Server(int Id, string Name, int Load, string Status, IReadOnlyCollection<Location> Locations, IReadOnlyCollection<Technology> Technologies);
