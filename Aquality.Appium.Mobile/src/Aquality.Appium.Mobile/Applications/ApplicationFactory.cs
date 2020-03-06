using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;

namespace Aquality.Appium.Mobile.Applications
{
    public abstract class ApplicationFactory : IApplicationFactory
    {
        public abstract IMobileApplication Application { get; }

        protected virtual AppiumDriver<AppiumWebElement> GetDriver(Uri serviceUrl)
        {
            var platformName = AqualityServices.ApplicationProfile.PlatformName;
            var driverOptions = AqualityServices.ApplicationProfile.DriverSettings.AppiumOptions;
            var commandTimeout = AqualityServices.Get<ITimeoutConfiguration>().Command;
            AppiumDriver<AppiumWebElement> driver;
            switch (platformName)
            {
                case PlatformName.Android:
                    driver = new AndroidDriver<AppiumWebElement>(serviceUrl, driverOptions, commandTimeout);
                    break;
                case PlatformName.IOS:
                    driver = new IOSDriver<AppiumWebElement>(serviceUrl, driverOptions, commandTimeout);
                    break;
                default:
                    throw GetLoggedWrongPlatformNameException(platformName.ToString());
            }

            return driver;
        }

        private PlatformNotSupportedException GetLoggedWrongPlatformNameException(string actualPlatform)
        {
            var message = AqualityServices.Get<ILocalizationManager>()
                .GetLocalizedMessage("loc.platform.name.wrong", actualPlatform);
            var exception = new PlatformNotSupportedException(message);
            AqualityServices.Logger.Fatal(message, exception);
            return exception;
        }

        protected void LogApplicationIsReady()
        {
            AqualityServices.LocalizedLogger.Info("loc.application.ready", AqualityServices.ApplicationProfile.PlatformName);
        }
    }
}
