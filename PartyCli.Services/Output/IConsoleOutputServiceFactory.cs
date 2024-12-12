namespace PartyCli.Services.Output
{
    /// <summary>
    /// Defines a factory for creating console output services.
    /// </summary>
    internal interface IConsoleOutputServiceFactory
    {
        /// <summary>
        /// Gets the console output service based on the specified format.
        /// </summary>
        /// <param name="format">The format of the console output service.</param>
        /// <returns>An instance of <see cref="IConsoleOutput"/>.</returns>
        IConsoleOutput GetConsoleOutputService(string format);
    }
}
