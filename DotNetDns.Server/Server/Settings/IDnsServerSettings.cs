using DotNetDns.Bootstrapper.Ioc.Attributes;

namespace DotNetDns.Server.Settings
{
    [Singleton]
    public interface IDnsServerSettings
    {
        int Port { get; }
    }
}