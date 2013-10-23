using DotNetDns.Common.Settings;
using DotNetDns.Server.Settings;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Server.Tests.Settings
{
    [TestFixture]
    public class DnsServerSettingsTests
    {
        [Test]
        public void Port_Is_Loaded_From_Settings_Service_With_Default_Value_Of_53()
        {
            var mockSettingsService = new Mocker<ISettingsService>().With(x => x.GetSettingByName("Port", 53), 53);
            var serverSettings = new DnsServerSettings(mockSettingsService.ToEntity());

            var port = serverSettings.Port;

            mockSettingsService.AssertWasCalledOnce(x => x.GetSettingByName("Port", 53));
            Assert.That(port, Is.EqualTo(53));
        }
    }
}