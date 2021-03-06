﻿using DotNetDns.Bootstrapper.Ioc.Attributes;
using DotNetDns.Common.Settings;
using DotNetDns.Server.Settings;

namespace DotNetDns.Server.Settings
{
    public class DnsServerSettings : IDnsServerSettings
    {
        private readonly ISettingsService _settingsService;

        public int Port 
        { 
            get { return _settingsService.GetSettingByName("Port", 53); } 
        }

        public DnsServerSettings(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
    }
}