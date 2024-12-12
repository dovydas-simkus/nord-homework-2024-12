namespace PartyCli.Services.Output.Models;

internal sealed partial record Server
{
    private static readonly string s_emptyValue = string.Empty;

    public static string TsvPrintHeader()
    {
        return string.Format("{0}\t{1}\t{2}\t{3}", nameof(Name), nameof(Load), nameof(Status), "Total");
    }

    public string TsvPrintDataLine()
    {
        return string.Format("{0}\t{1}\t{2}\t{3}", Name, Load, Status, s_emptyValue);
    }

    public static string TsvPrintTotalDataLine(int total)
    {
        return string.Format("{0}\t{1}\t{2}\t{3}", s_emptyValue, s_emptyValue, s_emptyValue, total);
    }
}
