using PartyCli.Domain.Querying;
using PartyCli.Persistence.AzureTables.Entities;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Provides methods for interacting with server data in Azure Table storage.
    /// </summary>
    internal sealed class ServerRepository : IServerRepository
    {
        private readonly ITableClientProvider _tableClientProvider;

        private const string TableName = "Servers";

        public ServerRepository(ITableClientProvider tableClientProvider)
        {
            _tableClientProvider = tableClientProvider;
        }

        /// <inheritdoc/>
        public async Task UpsertAsync(IAsyncEnumerable<Domain.Models.Server> servers, CancellationToken cancellationToken = default)
        {
            var table = _tableClientProvider.Get(TableName);

            await table.UpsertAsync(servers.Select(x => new Server(x)), cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<Domain.Models.Server> GetAsync(IQuery? query = null, CancellationToken cancellationToken = default)
        {
            var table = _tableClientProvider.Get(TableName);

            if (query is { })
            {
                var azureTablesQuery = query.ToAzureTablesQuery();

                if (azureTablesQuery.Filter != null)
                {
                    var filter = azureTablesQuery.Filter.And(Server.GetFilterForGetMany());

                    var queryString = filter.Build();

                    return table.GetAsync<Server>(queryString, cancellationToken).Select(entity => entity.ToModel());
                }
            }

            return table.GetAsync<Server>(Server.GetFilterForGetMany().Build(), cancellationToken).Select(entity => entity.ToModel());
        }
    }
}
