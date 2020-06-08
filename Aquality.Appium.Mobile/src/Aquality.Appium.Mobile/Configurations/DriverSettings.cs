using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aquality.Appium.Mobile.Configurations
{
    public class DriverSettings : IDriverSettings
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
                Capabilities.ToList().ForEach(capability => options.AddAdditionalCapability(capability.Key, capability.Value));
                if (HasApplicationPath && ApplicationPath != null)
                {
                    options.AddAdditionalCapability(AppCapabilityKey, ApplicationPath);
                }
                DeviceOptions.ToDictionary().ToList().ForEach(capability => options.AddAdditionalCapability(capability.Key, capability.Value));
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

        private AppiumOptions DeviceOptions
        {
            get
            {
                var deviceKey = settingsFile.GetValueOrDefault<string>($"{DriverSettingsPath}.{DeviceKeyKey}");
                var deviceSettings = new DeviceSettings(deviceKey);
                return deviceSettings.AppiumOptions;
            }
        }
    }
}
