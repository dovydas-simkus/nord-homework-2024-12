using Microsoft.Extensions.Options;

namespace PartyCli.NordVpnClient
{
    /// <summary>
    /// Represents the options for configuring the NordVPN client.
    /// </summary>
    internal sealed class NordVpnClientOptions : IOptions<NordVpnClientOptions>
    {
        /// <summary>
        /// The base URI for the NordVPN API.
        /// </summary>
        public Uri BaseUri { get; set; } = new("https://api.nordvpn.com");

        /// <summary>
        /// Gets the current NordVPN client options.
        /// </summary>
        public NordVpnClientOptions Value => this;
    }
}
