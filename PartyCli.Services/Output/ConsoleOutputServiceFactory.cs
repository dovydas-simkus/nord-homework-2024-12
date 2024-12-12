using System;

namespace PartyCli.Services.Output
{
    /// <inheritdoc />
    internal sealed class ConsoleOutputServiceFactory : IConsoleOutputServiceFactory
    {
        /// <inheritdoc />
        public IConsoleOutput GetConsoleOutputService(string format)
        {
            if (format == OutputFormats.Pretty)
            {
                return new PrettyConsoleOutput();
            }

            if (format == OutputFormats.Tsv)
            {
                return new TsvConsoleOutput();
            }

            if (format == OutputFormats.Json)
            {
                return new JsonConsoleOutput();
            }

            throw new ArgumentOutOfRangeException(nameof(format), format, $"'{format}' is not a supported output format.");
        }
    }
}
