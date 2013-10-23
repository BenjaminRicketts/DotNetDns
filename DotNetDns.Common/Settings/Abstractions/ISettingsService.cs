namespace DotNetDns.Common.Settings
{
    public interface ISettingsService
    {
        string GetSettingByName(string name);
        string GetSettingByName(string name, string defaultValue);
        T GetSettingByName<T>(string name);
        T GetSettingByName<T>(string name, T defaultValue);
    }
}