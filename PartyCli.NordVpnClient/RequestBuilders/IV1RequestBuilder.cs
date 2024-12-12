namespace PartyCli.NordVpnClient.RequestBuilders
{
    /// <summary>
    /// Defines the interface for building requests for the V1 API of the NordVPN client.
    /// </summary>
    public interface IV1RequestBuilder
    {
        /// <summary>
        /// Gets the request builder for the servers endpoint.
        /// </summary>
        IServersRequestBuilder Servers { get; }
    }
}
