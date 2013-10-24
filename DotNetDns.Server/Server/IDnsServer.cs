namespace DotNetDns.Server.Server
{
    public interface IDnsServer
    {
        void StartListening();
        void StopListening();
    }
}