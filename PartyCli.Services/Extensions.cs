using Microsoft.Extensions.DependencyInjection;
using PartyCli.Services.Mappers;
using PartyCli.Services.Output;
using PartyCli.Services.Providers;

namespace PartyCli.Services
{
    /// <summary>
    /// Provides extension methods for registering services.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Registers the services required by the application.
        /// </summary>
        /// <param name="serviceCollection">The service collection to add the services to.</param>
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IServerProvider, PersistentStoreServerProvider>();
            serviceCollection.AddTransient<IServerProvider, NordVpnApiServerProvider>();
            serviceCollection.AddTransient<IServerProviderFactory, ServerProviderFactory>();

            serviceCollection.AddTransient<ICommandOptionsToQueryMapper, CommandOptionsToQueryMapper>();

            serviceCollection.AddTransient<IConsoleOutputServiceFactory, ConsoleOutputServiceFactory>();
        }
    }
}
