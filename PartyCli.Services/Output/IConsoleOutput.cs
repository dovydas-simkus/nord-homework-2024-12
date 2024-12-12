using System.Collections.Generic;
using PartyCli.Domain.Models;

namespace PartyCli.Services.Output
{
    /// <summary>
    /// Defines the interface for console output services.
    /// </summary>
    internal interface IConsoleOutput
    {
        /// <summary>
        /// Outputs the server information asynchronously to the console.
        /// </summary>
        /// <param name="servers">The asynchronous enumerable of servers to output.</param>
        /// <returns>An asynchronous enumerable of servers.</returns>
        IAsyncEnumerable<Server> OutputAsync(IAsyncEnumerable<Server> servers);
    }
}
