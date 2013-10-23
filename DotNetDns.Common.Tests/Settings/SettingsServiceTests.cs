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
        public void Invalid_Setting_Name_Throw(string invalidName)
        {
            _settingsService.GetSettingByName(invalidName);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The 'MissingSetting' application setting cannot be found.")]
        public void Settings_That_Cannot_Be_Found_Throw()
        {
            _settingsService.GetSettingByName("MissingSetting");
        }

        [Test]
        public void Settings_Are_Returned_From_Application_Configuration()
        {
            var setting = _settingsService.GetSettingByName("SettingName");

            Assert.That(setting, Is.EqualTo("SettingValue"));
        }

        [Test]
        public void Generic_Settings_Are_Returned_From_Application_Configuration()
        {
            var setting = _settingsService.GetSettingByName<int>("IntegerSetting");

            Assert.That(setting, Is.EqualTo(123));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "An application setting cannot have a null or empty name.")]
        public void Invalid_Generic_Setting_Names_Throw(string invalidName)
        {
            _settingsService.GetSettingByName<int>(invalidName);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The 'MissingSetting' application setting cannot be found.")]
        public void Generic_Settings_That_Cannot_Be_Found_Throw()
        {
            _settingsService.GetSettingByName<int>("MissingSetting");
        }

        [Test]
        public void Default_Settings_Are_Returned_If_No_Setting_Can_Be_Found()
        {
            var expectedDefault = "default value";
            var value = _settingsService.GetSettingByName("MissingSetting", expectedDefault);

            Assert.That(value, Is.EqualTo(expectedDefault));
        }

        [Test]
        public void Default_Generic_Settings_Are_Returned_If_No_Setting_Can_Be_Found()
        {
            var expectedDefault = 12345;
            var value = _settingsService.GetSettingByName<int>("MissingSetting", expectedDefault);

            Assert.That(value, Is.EqualTo(expectedDefault));
        }
    }
}