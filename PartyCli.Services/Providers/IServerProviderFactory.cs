namespace PartyCli.Services.Providers
{
    /// <summary>
    /// Defines a factory for creating server providers.
    /// </summary>
    public interface IServerProviderFactory
    {
        /// <summary>
        /// Creates a server provider that uses a persistent store.
        /// </summary>
        /// <returns>An instance of <see cref="IServerProvider"/> that uses a persistent store.</returns>
        IServerProvider PersistentStore();

        /// <summary>
        /// Creates a server provider that uses the NordVPN API.
        /// </summary>
        /// <returns>An instance of <see cref="IServerProvider"/> that uses the NordVPN API.</returns>
        IServerProvider NordVpnApi();
    }
}
