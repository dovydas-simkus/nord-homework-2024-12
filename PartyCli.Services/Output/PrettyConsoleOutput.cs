using System;
using System.Collections.Generic;
using PartyCli.Domain.Models;

namespace PartyCli.Services.Output
{
    internal sealed class PrettyConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// Printing servers to the console.
        /// Example:
        /// | Name        | Load   | Status  |
        /// |-------------|--------|---------|
        /// | Server #1   | 20     | online  |
        /// |-------------|--------|---------|
        /// | Total count | 1      |         |
        /// </summary>
        public async IAsyncEnumerable<Server> OutputAsync(IAsyncEnumerable<Server> servers)
        {
            // Print the table header
            Console.WriteLine(Models.Server.PrettyPrintHeader());
            Console.WriteLine(Models.Server.PrettyPrintSeparator());

            var serverCount = 0;

            await foreach (var server in servers)
            {
                var serverModel = Models.Server.FromDomainModel(server);

                // Print the server data line
                Console.WriteLine(serverModel.PrettyPrintDataLine());

                serverCount++;

                yield return server;
            }

            // Print the table footer with the total count of servers
            Console.WriteLine(Models.Server.PrettyPrintSeparator());
            Console.WriteLine(Models.Server.PrettyPrintTotalDataLine(serverCount));
        }
    }
}
