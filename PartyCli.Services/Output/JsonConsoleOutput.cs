using System;
using System.Collections.Generic;
using System.Text.Json;
using PartyCli.Domain.Models;

namespace PartyCli.Services.Output
{
    internal sealed class JsonConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// Printing servers to the console as JSON.
        /// Example:
        /// {
        ///     "servers": [
        ///         {
        ///             "name": "Server #1",
        ///             "load": 20,
        ///             "status": "online",
        ///         }
        ///     ],
        ///     "total": 1
        /// }
        /// </summary>
        public async IAsyncEnumerable<Server> OutputAsync(IAsyncEnumerable<Server> servers)
        {
            await using (var jsonWriter = new Utf8JsonWriter(Console.OpenStandardOutput(), new JsonWriterOptions { Indented = true }))
            {
                // {
                jsonWriter.WriteStartObject();

                // "servers":
                jsonWriter.WritePropertyName("servers");

                // [
                jsonWriter.WriteStartArray();

                var serverCount = 0;

                await foreach (var server in servers)
                {
                    var serverModel = Models.Server.FromDomainModel(server);

                    JsonSerializer.Serialize(jsonWriter, serverModel);

                    serverCount++;

                    yield return server;
                }

                // ]
                jsonWriter.WriteEndArray();

                // "total":
                jsonWriter.WritePropertyName("total");

                // "total": <serverCount>
                jsonWriter.WriteNumberValue(serverCount);

                // }
                jsonWriter.WriteEndObject();
            }
        }
    }
}
