namespace PartyCli.Persistence.AzureTables
{
    /// <summary>
    /// Defines the interface for a provider that supplies table clients.
    /// </summary>
    internal interface ITableClientProvider
    {
        /// <summary>
        /// Gets a table client for the specified table name.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <returns>An instance of <see cref="ITableClient"/> for the specified table.</returns>
        ITableClient Get(string tableName);
    }
}
