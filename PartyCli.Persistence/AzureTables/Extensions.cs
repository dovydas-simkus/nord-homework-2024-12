using Microsoft.Extensions.DependencyInjection;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Provides extension methods for registering Azure Table services.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Registers the Azure Table services with the specified service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection to add the services to.</param>
        public static void RegisterAzureTables(this IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<AzureStorageOptions>(options =>
            {
                options.ConnectionString = "UseDevelopmentStorage=true";
            });
            serviceCollection.AddTransient<ITableClientProvider, TableClientProvider>();
        }
    }
}
