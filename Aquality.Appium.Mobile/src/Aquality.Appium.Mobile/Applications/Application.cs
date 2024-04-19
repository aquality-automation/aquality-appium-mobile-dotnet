using Aquality.Appium.Mobile.Configurations;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;
using System;

namespace Aquality.Appium.Mobile.Applications
{
    public class Application : IMobileApplication
    {
        private readonly ILocalizedLogger localizedLogger;
        private readonly IApplicationProfile applicationProfile;
        
        private TimeSpan timeoutImplicit;

        public Application(AppiumDriver driver, AppiumLocalService driverService = null)
        {
            Driver = driver;
            DriverService = driverService;
            localizedLogger = AqualityServices.LocalizedLogger;
            applicationProfile = AqualityServices.ApplicationProfile;
            SetImplicitlyWaitToDriver(AqualityServices.Get<ITimeoutConfiguration>().Implicit);
        }

        private void SetImplicitlyWaitToDriver(TimeSpan timeout)
        {
            Driver.Manage().Timeouts().ImplicitWait = timeout;
            timeoutImplicit = timeout;
        }

        WebDriver IApplication.Driver => Driver;

        public bool IsStarted => Driver.SessionId != null;

        public AppiumDriver Driver { get; }

        public AppiumLocalService DriverService { get; }

        public PlatformName PlatformName => applicationProfile.PlatformName;

        public void SetImplicitWaitTimeout(TimeSpan timeout)
        {
            if (timeout != timeoutImplicit)
            {
                localizedLogger.Debug("loc.application.implicit.timeout", args: timeout.TotalSeconds);
                SetImplicitlyWaitToDriver(timeoutImplicit);
            }
        }

        public void Quit()
        {
            localizedLogger.Info("loc.application.quit");
            Driver?.Quit();
            DriverService?.Dispose();
        }

        public bool TerminateApp(string bundleId)
        {
            return ((IInteractsWithApps)Driver).TerminateApp(bundleId);
        }
    }
}
