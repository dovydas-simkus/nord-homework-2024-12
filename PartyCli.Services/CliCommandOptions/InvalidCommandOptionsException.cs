using System;

namespace PartyCli.Services.CliCommandOptions;

public sealed class InvalidCommandOptionsException : Exception
{
    public InvalidCommandOptionsException(string message) : base(message)
    {
    }
}
