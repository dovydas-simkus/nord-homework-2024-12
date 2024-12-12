using System;
using System.Collections.Generic;
using PartyCli.Domain.Models;

namespace PartyCli.Services.Output
{
    internal sealed class TsvConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// Printing servers to the console as TSV.
        /// Example:
        /// Name    Load    Status    Total
        /// Server #1    20    online
        ///                 1
        /// </summary>
        public async IAsyncEnumerable<Server> OutputAsync(IAsyncEnumerable<Server> servers)
        {
            // Print header line
            Console.WriteLine(Models.Server.TsvPrintHeader());

            var serverCount = 0;

            await foreach (var server in servers)
            {
                var serverModel = Models.Server.FromDomainModel(server);

                // Print the server data line
                Console.WriteLine(serverModel.TsvPrintDataLine());

                serverCount++;

                yield return server;
            }

            // Print total server count data line
            Console.WriteLine(Models.Server.TsvPrintTotalDataLine(serverCount));
        }
    }
}
