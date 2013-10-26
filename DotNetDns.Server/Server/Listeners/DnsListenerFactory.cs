using System.Collections.Generic;
using DotNetDns.Server.Settings;

namespace DotNetDns.Server.Server.Listeners
{
    public class DnsListenerFactory : IDnsListenerFactory
    {
        private readonly IDnsServerSettings _serverSettings;

        public DnsListenerFactory(IDnsServerSettings serverSettings)
        {
            _serverSettings = serverSettings;
        }

        public IList<IDnsListener> CreateListeners()
        {
            return new List<IDnsListener>
            {
                new UdpListener(_serverSettings)
            };
        }
    }
}