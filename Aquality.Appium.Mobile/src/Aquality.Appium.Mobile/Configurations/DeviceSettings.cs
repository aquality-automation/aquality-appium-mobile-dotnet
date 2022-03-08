using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Core.Utilities;
using System.Collections.Generic;

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

        public IReadOnlyDictionary<string, object> Capabilities => settingsFile.GetValueDictionaryOrEmpty<object>($"{deviceKey}.capabilities");
    }
}
