namespace PartyCli.NordVpnClient
{
    public sealed class NordVpnClientException : Exception
    {
        public NordVpnClientException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
