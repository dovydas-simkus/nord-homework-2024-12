using PartyCli.NordVpnClient.RequestBuilders;

namespace PartyCli.NordVpnClient
{
    /// <summary>
    /// Defines the interface for the NordVPN client.
    /// </summary>
    public interface INordVpnClient
    {
        /// <summary>
        /// Gets the request builder for the V1 API.
        /// </summary>
        IV1RequestBuilder V1 { get; }
    }
}
