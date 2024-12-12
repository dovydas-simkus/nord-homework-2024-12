using PartyCli.Domain.Models;
using PartyCli.Domain.Querying;
using PartyCli.Persistence;

namespace PartyCli.Services.Providers
{
    /// <summary>
    /// Provides server data from a persistent store.
    /// </summary>
    internal sealed class PersistentStoreServerProvider : IServerProvider
    {
        private readonly IServerRepository _serverRepository;

        public PersistentStoreServerProvider(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        /// <inheritdoc />
        public IAsyncEnumerable<Server> GetAsync(IQuery? query, CancellationToken cancellationToken = default)
        {
            return _serverRepository.GetAsync(query, cancellationToken);
        }
    }
}
