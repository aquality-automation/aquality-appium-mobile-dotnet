using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using NUnit.Framework;
using System;
using System.Linq;

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
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Any());
        }

        [Test]
        public void Should_BePossible_ToGetEmptyCapabilitiesWhenDeviceKeyIsNull()
        {
            var deviceSettings = new DeviceSettings(null);
            var options = deviceSettings.Capabilities;
            Assert.IsNotNull(options);
            Assert.IsFalse(options.Any());
        }

        [Test]
        public void Should_BePossible_ToUseDifferentDevicesProfiles()
        {
            Environment.SetEnvironmentVariable(DevicesProfilePropertyKey, "test");
            var deviceSettings = new DeviceSettings("iPhone_11");
            var options = deviceSettings.Capabilities;
            Assert.AreEqual("iPhone 11 test", options["deviceName"]);

            Environment.SetEnvironmentVariable(DevicesProfilePropertyKey, null);
            deviceSettings = new DeviceSettings("iPhone_11");
            options = deviceSettings.Capabilities;
            Assert.AreEqual("iPhone 11", options["deviceName"]);
        }

        [Test]
        public void Should_BePossible_ToGetDefaultDeviceSettingsForIosPlatform()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "ios");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "iPhone_11");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.AreEqual("iPhone 11", options.DeviceName);
        }

        [Test]
        public void Should_BePossible_ToGetDefaultDeviceSettingsForAndroidPlatform()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "android");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "Nexus");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.AreEqual("Nexus", options.DeviceName);
        }

        [Test]
        public void Should_BePossible_ToOverrideDefaultDevice()
        {
            Environment.SetEnvironmentVariable(PlatformNamePropertyKey, "android");
            Environment.SetEnvironmentVariable(DevicesKeyPropertyKey, "Samsung_Galaxy");
            var options = AqualityServices.Get<IApplicationProfile>().DriverSettings.AppiumOptions;
            Assert.AreEqual("Samsung Galaxy", options.DeviceName);
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
