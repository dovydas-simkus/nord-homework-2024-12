namespace PartyCli.Services.Output.Models;

internal sealed partial record Server
{
    public static string PrettyPrintSeparator()
    {
        return string.Format("| {0, -25} | {1, -10} | {2, -10} |", "---------", "---------", "---------");
    }

    public static string PrettyPrintHeader()
    {
        return string.Format("| {0, -25} | {1, -10} | {2, -10} |", nameof(Name), nameof(Load), nameof(Status));
    }

    public string PrettyPrintDataLine()
    {
        return string.Format("| {0, -25} | {1, -10} | {2, -10} |", Name, Load, Status);
    }

    public static string PrettyPrintTotalDataLine(int total)
    {
        return string.Format("| {0, -25} | {1, -10} | {2, -10} |", "Total count", total, string.Empty);
    }
}
