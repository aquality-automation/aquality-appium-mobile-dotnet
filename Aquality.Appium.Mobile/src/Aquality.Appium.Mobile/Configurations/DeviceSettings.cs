using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Configurations
{
    public class DeviceSettings : IDeviceSettings
    {
        private readonly ISettingsFile settingsFile;
        private readonly string deviceKey;

        public DeviceSettings(string deviceKey)
        {
            settingsFile = GetDevicesSettings();
            this.deviceKey = deviceKey;
        }

        private ISettingsFile GetDevicesSettings()
        {
            var deviceProfileName = EnvironmentConfiguration.GetVariable("devicesProfile");
            var devicesProfile = deviceProfileName == null 
                ? "devices.json" 
                : $"devices.{deviceProfileName}.json";
            Logger.Instance.Debug($"Get devices settings from: {devicesProfile}");
            return new JsonSettingsFile(devicesProfile);
        }

        public AppiumOptions AppiumOptions
        {
            get
            {
                var deviceOptions = new AppiumOptions();
                Capabilities.ToList().ForEach(capability => deviceOptions.AddAdditionalCapability(capability.Key, capability.Value));
                return deviceOptions;
            }
        }

        private IDictionary<string, object> Capabilities => settingsFile.GetValueOrNew<Dictionary<string, object>>($"{deviceKey}.capabilities");
    }
}
