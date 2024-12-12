using Microsoft.Extensions.Options;
using PartyCli.NordVpnClient.RequestBuilders;

namespace PartyCli.NordVpnClient
{
    /// <inheritdoc/>
    internal sealed class NordVpnClient : INordVpnClient
    {
        private readonly HttpClient _httpClient;

        public NordVpnClient(IHttpClientFactory httpClientFactory, IOptions<NordVpnClientOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = options.Value.BaseUri;
        }

        /// <inheritdoc/>
        public IV1RequestBuilder V1 => new V1RequestBuilder(_httpClient);
    }
}
