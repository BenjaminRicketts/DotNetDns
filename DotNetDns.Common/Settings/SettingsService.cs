using System;
using System.ComponentModel;
using System.Configuration;

namespace DotNetDns.Common.Settings
{
    public class SettingsService : ISettingsService
    {
        public string GetSettingByName(string name)
        {
            var value = GetSettingValue(name);

            if (value == null)
                throw new Exception(string.Format("The '{0}' application setting cannot be found.", name));

            return value;
        }

        public string GetSettingByName(string name, string defaultValue)
        {
            var value = GetSettingValue(name);

            return value == null ? defaultValue : value;
        }

        public T GetSettingByName<T>(string name)
        {
            return ConvertFromString<T>(GetSettingByName(name));
        }

        public T GetSettingByName<T>(string name, T defaultValue)
        {
            var value = GetSettingValue(name);

            return value == null ? defaultValue : ConvertFromString<T>(value);
        }

        private T ConvertFromString<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        private string GetSettingValue(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("An application setting cannot have a null or empty name.");

            return ConfigurationManager.AppSettings[name];
        }
    }
}