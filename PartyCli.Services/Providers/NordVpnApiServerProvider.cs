using PartyCli.Domain.Classifiers;
using PartyCli.Domain.Querying;
using PartyCli.NordVpnClient;
using PartyCli.NordVpnClient.Models;
using Country = PartyCli.Domain.Classifiers.Country;
using Server = PartyCli.Domain.Models.Server;

namespace PartyCli.Services.Providers
{
    /// <summary>
    /// Provides server data from the NordVPN API.
    /// </summary>
    internal sealed class NordVpnApiServerProvider : IServerProvider
    {
        private readonly INordVpnClient _nordVpnClient;

        public NordVpnApiServerProvider(INordVpnClient nordVpnClient)
        {
            _nordVpnClient = nordVpnClient;
        }

        /// <inheritdoc />
        public IAsyncEnumerable<Server> GetAsync(IQuery? query, CancellationToken cancellationToken = default)
        {
            var servers = _nordVpnClient.V1.Servers.GetAsync(query, cancellationToken);

            return servers.Select(Map);
        }

        private static Server Map(NordVpnClient.Models.Server server)
        {
            return new Server(
                Id: server.Id,
                Name: server.Name,
                Load: server.Load,
                Status: server.Status,
                VpnProtocols: MapVpnProtocols(server),
                Country: MapCountry(server)
            );
        }

        private static Country MapCountry(NordVpnClient.Models.Server server)
        {
            var serverLocation = server.Locations.FirstOrDefault();

            return serverLocation?.Country.Id switch
            {
                74 => Country.France,
                _ => Country.Unknown
            };
        }

        private static IReadOnlyCollection<VpnProtocol> MapVpnProtocols(NordVpnClient.Models.Server server)
        {
            var vpnProtocols = new List<VpnProtocol>();

            foreach (var technology in server.Technologies)
            {
                vpnProtocols.Add(MapTechnology(technology));
            }

            return vpnProtocols;
        }

        private static VpnProtocol MapTechnology(Technology technology)
        {
            return technology.Id switch
            {
                5 => VpnProtocol.Tcp,
                _ => VpnProtocol.Unknown,
            };
        }
    }
}
