using System.Runtime.CompilerServices;
using System.Text.Json;
using PartyCli.Domain.Querying;
using PartyCli.NordVpnClient.Models;
using PartyCli.NordVpnClient.Querying;

namespace PartyCli.NordVpnClient.RequestBuilders
{
    /// <inheritdoc/>
    internal sealed class ServersRequestBuilder : IServersRequestBuilder
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiVersion;

        public ServersRequestBuilder(HttpClient httpClient, string apiVersion)
        {
            _httpClient = httpClient;
            _apiVersion = apiVersion;
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<Server> GetAsync(IQuery? query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"{_apiVersion}/servers");

            if (query is { })
            {
                var nordVpnQuery = query.ToNordVpnClientQuery();

                var queryString = nordVpnQuery.Build();

                if (string.IsNullOrWhiteSpace(queryString))
                {
                    throw new ArgumentException("Query cannot be empty.");
                }

                request = new HttpRequestMessage(HttpMethod.Get, $"{_apiVersion}/servers?{queryString}");
            }

            HttpResponseMessage? response;

            try
            {
                response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new NordVpnClientException("Unable to list servers.", e);
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            var enumerable = JsonSerializer.DeserializeAsyncEnumerable<Server>(responseStream,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase },
                cancellationToken);

            await foreach (var server in enumerable)
            {
                if (server != null)
                {
                    yield return server;
                }
            }
        }
    }
}
