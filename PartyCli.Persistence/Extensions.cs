using Microsoft.Extensions.DependencyInjection;
using PartyCli.Persistence.AzureTables;

namespace PartyCli.Persistence
{
    /// <summary>
    /// Provides extension methods for registering persistence services.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Registers the persistence services required by the application.
        /// </summary>
        /// <param name="serviceCollection">The service collection to add the services to.</param>
        public static void RegisterPersistence(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAzureTables();
            serviceCollection.AddTransient<IServerRepository, ServerRepository>();
        }
    }
}
