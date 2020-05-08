using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            var jsonFile = FileReader.IsResourceFileExist(devicesProfile)
                ? new JsonSettingsFile(devicesProfile)
                : new JsonSettingsFile($"Resources.{devicesProfile}", Assembly.GetCallingAssembly());
            return jsonFile;
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
