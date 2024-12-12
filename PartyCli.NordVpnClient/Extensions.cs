using Microsoft.Extensions.DependencyInjection;

namespace PartyCli.NordVpnClient
{
    /// <summary>
    /// Provides extension methods for registering the NordVPN client services.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Registers the NordVPN client services with the specified service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection to add the services to.</param>
        public static void RegisterNordVpnClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient();
            serviceCollection.AddTransient<INordVpnClient, NordVpnClient>();
        }
    }
}
