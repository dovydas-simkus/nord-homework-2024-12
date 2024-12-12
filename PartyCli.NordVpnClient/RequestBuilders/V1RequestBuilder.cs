namespace PartyCli.NordVpnClient.RequestBuilders
{
    /// <inheritdoc/>
    internal sealed class V1RequestBuilder : IV1RequestBuilder
    {
        private const string ApiVersion = "v1";

        private readonly HttpClient _httpClient;

        public V1RequestBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public IServersRequestBuilder Servers => new ServersRequestBuilder(_httpClient, ApiVersion);
    }
}
