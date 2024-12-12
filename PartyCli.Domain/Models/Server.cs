using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Querying.Filtering;

namespace PartyCli.Domain.Models
{
    [SupportsFilter(nameof(PropertyFilters.Country))]
    [SupportsFilter(nameof(PropertyFilters.VpnProtocol))]
    public sealed record Server(int Id, string Name, int Load, string Status, IReadOnlyCollection<VpnProtocol> VpnProtocols, Country Country);
}
