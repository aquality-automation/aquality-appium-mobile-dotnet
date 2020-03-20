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
        private readonly ISettingsFile settingsFile;
        private readonly PlatformName platformName;

        public DriverSettings(ISettingsFile settingsFile, PlatformName platformName)
        {
            this.settingsFile = settingsFile;
            this.platformName = platformName;
        }

        private string DriverSettingsPath => $".driverSettings.{platformName.ToString().ToLower()}";

        private string ApplicationPathJPath => $"{DriverSettingsPath}.{ApplicationPathKey}";

        protected IDictionary<string, object> Capabilities => settingsFile.GetValueOrNew<Dictionary<string, object>>($"{DriverSettingsPath}.capabilities");

        /// <summary>
        /// Defines does the current settings have the application path defined
        /// </summary>
        protected bool HasApplicationPath => settingsFile.IsValuePresent(ApplicationPathJPath);

        public AppiumOptions AppiumOptions
        {
            get
            {
                var options = new AppiumOptions();
                Capabilities.ToList().ForEach(capability => options.AddAdditionalCapability(capability.Key, capability.Value));
                if (HasApplicationPath)
                {
                    options.AddAdditionalCapability(AppCapabilityKey, ApplicationPath);
                }
                return options;
            }
        }

        public string ApplicationPath => Path.GetFullPath(settingsFile.GetValue<string>(ApplicationPathJPath));
    }
}
