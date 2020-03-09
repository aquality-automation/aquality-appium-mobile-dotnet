using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System;

namespace Aquality.Appium.Mobile.Configurations
{
    public class ApplicationProfile : IApplicationProfile
    {
        private readonly ISettingsFile settingsFile;

        public ApplicationProfile(ISettingsFile settingsFile)
        {
            this.settingsFile = settingsFile;
        }

        public IDriverSettings DriverSettings => new DriverSettings(settingsFile, PlatformName);

        public bool IsRemote => settingsFile.GetValue<bool>(".isRemote");

        public PlatformName PlatformName => settingsFile.GetValue<string>(".platformName").ToEnum<PlatformName>();

        public Uri RemoteConnectionUrl => new Uri(settingsFile.GetValue<string>(".remoteConnectionUrl"));
    }
}
