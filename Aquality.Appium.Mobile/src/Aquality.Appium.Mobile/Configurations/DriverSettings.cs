using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aquality.Appium.Mobile.Configurations
{
    public class DriverSettings : CapabilityBasedSettings, IDriverSettings
    {
        private const string ApplicationPathKey = "applicationPath";
        private const string AppCapabilityKey = "app";
        private const string DeviceKeyKey = "deviceKey";

        private readonly ISettingsFile settingsFile;
        private readonly PlatformName platformName;

        public DriverSettings(ISettingsFile settingsFile, PlatformName platformName)
        {
            this.settingsFile = settingsFile;
            this.platformName = platformName;
        }

        private string DriverSettingsPath => $".driverSettings.{platformName.ToString().ToLower()}";

        private string ApplicationPathJPath => $"{DriverSettingsPath}.{ApplicationPathKey}";

        protected virtual IReadOnlyDictionary<string, object> Capabilities => settingsFile.GetValueDictionaryOrEmpty<object>($"{DriverSettingsPath}.capabilities");

        /// <summary>
        /// Defines does the current settings have the application path defined
        /// </summary>
        protected virtual bool HasApplicationPath => settingsFile.IsValuePresent(ApplicationPathJPath) || Capabilities.ContainsKey(AppCapabilityKey);

        public virtual AppiumOptions AppiumOptions
        {
            get
            {
                var options = new AppiumOptions();
                Capabilities.ToList().ForEach(capability => SetCapability(options, capability));
                if (HasApplicationPath && ApplicationPath != null)
                {
                    SetCapability(options, new KeyValuePair<string, object> (AppCapabilityKey, ApplicationPath));
                }
                DeviceCapabilities.ToList().ForEach(capability => SetCapability(options, capability));
                return options;
            }
        }

        public virtual string ApplicationPath
        {
            get
            {
                var appValue = settingsFile.GetValueOrDefault(ApplicationPathJPath,
                    defaultValue: (Capabilities.ContainsKey(AppCapabilityKey) ? Capabilities[AppCapabilityKey] : null)?.ToString());
                return appValue?.StartsWith(".") == true ? Path.GetFullPath(appValue) : appValue;
            }
        }

        private IReadOnlyDictionary<string, object> DeviceCapabilities
        {
            get
            {
                var deviceKey = settingsFile.GetValueOrDefault<string>($"{DriverSettingsPath}.{DeviceKeyKey}");
                var deviceSettings = new DeviceSettings(deviceKey);
                return deviceSettings.Capabilities;
            }
        }
    }
}
