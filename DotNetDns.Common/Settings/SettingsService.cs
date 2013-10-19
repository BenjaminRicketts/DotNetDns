using System;
using System.Configuration;

namespace DotNetDns.Common.Settings
{
    public class SettingsService : ISettingsService
    {
        public string GetSettingByName(string name)
        {
            ValidateSettingName(name);

            var value = ConfigurationManager.AppSettings[name];

            ValidateSettingValue(name, value);

            return value;
        }

        private void ValidateSettingName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("An application setting cannot have a null or empty name.");
        }

        private void ValidateSettingValue(string name, string value)
        {
            if (value == null)
                throw new Exception(string.Format("The '{0}' application setting cannot be found.", name));
        }
    }
}