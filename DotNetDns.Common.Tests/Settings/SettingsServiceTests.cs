using System;
using DotNetDns.Common.Settings;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Settings
{
    [TestFixture]
    public class SettingsServiceTests
    {
        private SettingsService _settingsService;

        [SetUp]
        public void SetupTest()
        {
            _settingsService = new SettingsService();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "An application setting cannot have a null or empty name.")]
        public void Invalid_Setting_Name_Throws(string invalidName)
        {
            _settingsService.GetSettingByName(invalidName);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The 'MissingSetting' application setting cannot be found.")]
        public void Settings_That_Cannot_Be_Found_Throws()
        {
            _settingsService.GetSettingByName("MissingSetting");
        }

        [Test]
        public void Settings_Are_Returned_From_Application_Configuration()
        {
            var setting = _settingsService.GetSettingByName("SettingName");

            Assert.That(setting, Is.EqualTo("SettingValue"));
        }
    }
}