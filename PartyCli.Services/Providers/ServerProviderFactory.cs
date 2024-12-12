using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyCli.Services.Providers
{
    /// <summary>
    /// Factory for creating server providers.
    /// </summary>
    internal sealed class ServerProviderFactory : IServerProviderFactory
    {
        private readonly IEnumerable<IServerProvider> _serverProviders;

        public ServerProviderFactory(IEnumerable<IServerProvider> serverProviders)
        {
            _serverProviders = serverProviders;
        }

        /// <summary>
        /// Creates a server provider that uses a persistent store.
        /// </summary>
        /// <returns>An instance of <see cref="PersistentStoreServerProvider"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown when no persistent store server provider is found.</exception>
        public IServerProvider PersistentStore()
        {
            return _serverProviders.OfType<PersistentStoreServerProvider>().FirstOrDefault() ?? throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a server provider that uses the NordVPN API.
        /// </summary>
        /// <returns>An instance of <see cref="NordVpnApiServerProvider"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown when no NordVPN API server provider is found.</exception>
        public IServerProvider NordVpnApi()
        {
            return _serverProviders.OfType<NordVpnApiServerProvider>().FirstOrDefault() ?? throw new NotSupportedException();
        }
    }
}
