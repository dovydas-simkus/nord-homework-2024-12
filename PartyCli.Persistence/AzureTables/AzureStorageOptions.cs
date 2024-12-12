using Microsoft.Extensions.Options;

namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Represents the options for Azure Storage configuration.
    /// </summary>
    internal sealed class AzureStorageOptions : IOptions<AzureStorageOptions>
    {
        /// <summary>
        /// Connection string for Azure Storage.
        /// </summary>
        public string ConnectionString { get; set; } = null!;

        /// <summary>
        /// Gets the current instance of <see cref="AzureStorageOptions"/>.
        /// </summary>
        public AzureStorageOptions Value => this;
    }
}
