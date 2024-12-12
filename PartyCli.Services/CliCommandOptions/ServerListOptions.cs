using CommandLine;

namespace PartyCli.Services.CliCommandOptions
{
    /// <summary>
    /// Represents the options for the server_list command.
    /// </summary>
    [Verb("server_list", isDefault: false, HelpText = "List servers.")]
    public sealed class ServerListOptions : ICommandOptions
    {
        /// <summary>
        /// A value indicating whether to filter France servers.
        /// </summary>
        [Option(OptionNames.France, HelpText = "Filter France servers.")]
        public bool FilterByFrance { get; set; }

        /// <summary>
        /// A value indicating whether to filter TCP protocol servers.
        /// </summary>
        [Option(OptionNames.TCP, HelpText = "Filter TCP protocol servers.")]
        public bool FilterByTcp { get; set; }

        /// <summary>
        /// A value indicating whether to list servers from the persistent store.
        /// </summary>
        [Option(OptionNames.Local, HelpText = "List servers from persistent store.")]
        public bool FetchLocal { get; set; }

        [Option(OptionNames.Output, HelpText = "Output format. Such as: pretty, json, tsv. Default is pretty.")]
        public string? OutputFormat { get; set; }

        private class OptionNames
        {
            public const string France = "france";
            public const string TCP = "TCP";
            public const string Local = "local";
            public const string Output = "output";
        }

        public class SupportedOutputFormats
        {
            public const string Default = Pretty;
            public const string Pretty = Output.OutputFormats.Pretty;
            public const string Json = Output.OutputFormats.Json;
            public const string Tsv = Output.OutputFormats.Tsv;
        }
    }
}
