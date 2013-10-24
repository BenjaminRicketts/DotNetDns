using System;
using System.Net;
using DotNetDns.Server.Settings;

namespace DotNetDns.Server.Server.Listeners
{
    public class UdpListener : IDnsListener
    {
        private readonly IDnsServerSettings _settings;

        public UdpListener(IDnsServerSettings settings)
        {
            _settings = settings;

            ValidateSettings();
        }

        public void StartListening()
        {
            throw new NotImplementedException();
        }

        private void ValidateSettings()
        {
            if (_settings == null)
                throw new Exception("No DNS server settings have been found.");
        }
    }
}