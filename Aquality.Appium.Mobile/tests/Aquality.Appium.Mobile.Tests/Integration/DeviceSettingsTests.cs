using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using NUnit.Framework;
using System;

namespace Aquality.Appium.Mobile.Tests.Integration
{
    public class DeviceSettingsTests
    {
        private const string PlatformNamePropertyKey = "platformName";
        private const string DevicesProfilePropertyKey = "devicesProfile";
        private const string DevicesKeyPropertyKey = "driverSettings.android.deviceKey";

        [Test]
        public void Should_BePossible_ToGetDeviceCapabilities()
        {
            var deviceSettings = new DeviceSettings("iPhone_11");
            var options = deviceSettings.Capabilities;
            Assert.That(options, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Should_BePossible_ToGetEmptyCapabilitiesWhenDeviceKeyIsNull()
        {
            var deviceSettings = new DeviceSettings(null);
            var options = deviceSettings.Capabilities;
            Assert.That(options, Is.Not.Null.And.Empty);
        }

        [Test]
        public void Should_BePossible_ToUseDifferentDevicesProfiles()
        {
            Environment.SetEnvironmentVariable(DevicesProfilePropertyKey, "test");
            var deviceSettings = new DeviceSettings("iPhone_11");
            var options = deviceSettings.Capabilities;
            Assert.That(options["deviceName"], Is.EqualTo("iPhone 11 test"));

            Environment.SetEnvironmentVariable(DevicesProfilePropertyKey, null);
            deviceSettings = new DeviceSettings("iPhone_11");
            options = deviceSettings.Capabilities;
            Assert.That(options["deviceName"], Is.EqualTo("iPhone 11"));
        }

        [Test]
        public void Should_BePossible_ToGetDefaultDeviceSettingsForIosPlatform()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "ios");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "iPhone_11");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.That(options.DeviceName, Is.EqualTo("iPhone 11"));
        }

        [Test]
        public void Should_BePossible_ToGetDefaultDeviceSettingsForAndroidPlatform()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "android");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "Nexus");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.That(options.DeviceName, Is.EqualTo("Nexus"));
        }

        [Test]
        public void Should_BePossible_ToOverrideDefaultDevice()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "android");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "Samsung_Galaxy");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.That(options.DeviceName, Is.EqualTo("Samsung Galaxy"));
        }

        [TearDown]
        public void TearDown()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, null);
            Environment.SetEnvironmentVariable(DevicesProfilePropertyKey, null);
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, null);
            AqualityServices.SetStartup(new MobileStartup());
        }
    }
}
