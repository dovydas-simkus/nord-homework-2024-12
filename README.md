# Homework task solution

PartyCli is a command-line interface (CLI) application designed to interact with various services, including the NordVPN REST API and Azure Table storage.
It provides functionalities for querying and filtering data (currently only NordVPN servers) and outputs results to the console in different formats.

## Starting point
- Starter code - [NordVPN.Windows.Task](NordVPN.Windows.Task.zip)
- Task description - [NordVPN.Windows.Task](NordVPN.Windows.Task.pdf)

## Features

- **NordVPN REST API Integration**: Query and filter data using the NordVPN client.
- **[Azure Table storage](https://learn.microsoft.com/en-us/azure/storage/tables/table-storage-overview) persistence**: Store and retrieve data from Azure Tables.
- **CLI command handling services**: Handle commands provided through CLI and output results to the console in various formats.

## Getting Started

### Prerequisites

- .NET 8
- [Azurite](https://github.com/Azure/Azurite) as a persistent store solution for local development

### Project Structure

- `PartyCli.App`: Contains the main console application.
- `PartyCli.Domain`: Contains domain logic and interfaces for querying and filtering.
- `PartyCli.NordVpnClient`: Implements the NordVPN client and related query functionalities.
- `PartyCli.Persistence`: Provides data persistence functionality using Azure Tables storage.
- `PartyCli.Services`: Contains the main logic and services for handling CLI commands and asynchronously printing their results to console.

### Usage examples

To list arguments supported by the **server_list** command, use the following command:
```sh
dotnet run --project PartyCli.App server_list --help
```

To query data using the NordVPN client and output the results to the console in a JSON format, use the following command:
```sh
dotnet run --project PartyCli.App server_list --france --output json
```

To query data using the persistence store and output the results to the console in a "Pretty"(this is the default output format) format, use the following command:
```sh
dotnet run --project PartyCli.App server_list --local --output pretty
```

## Points of improvement
- A different persistence store solution could be used instead of Azure Tables to support storing and querying nested object data.
Examples such as MongoDB or CosmosDB could be considered.
- Implement more query functionalities for the NordVPN client to support more advanced filtering options.
- Improve console printing part to support different use cases(more formats, colors, etc.).
- Add verbose logging to the application to help with debugging and monitoring.
