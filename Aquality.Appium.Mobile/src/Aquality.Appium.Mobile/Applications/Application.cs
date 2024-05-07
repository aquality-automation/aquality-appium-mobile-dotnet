using Aquality.Appium.Mobile.Configurations;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;

namespace Aquality.Appium.Mobile.Applications
{
    // Ignore Spelling: app
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

        public string Id => PlatformName.Android == PlatformName
                ? ((AndroidDriver)Driver).CurrentPackage
                : applicationProfile.DriverSettings.BundleId;

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

        public bool Terminate(TimeSpan? timeout = null)
        {
            return Terminate(Id, timeout);
        }

        public bool Terminate(string appId, TimeSpan? timeout = null)
        {
            localizedLogger.Info("loc.application.terminate", appId);
            return timeout.HasValue 
                ? Driver.TerminateApp(appId, timeout.Value)
                : Driver.TerminateApp(appId);
        }

        public void Install(string appPath)
        {
            localizedLogger.Info("loc.application.install", appPath);
            Driver.InstallApp(appPath);
        }

        public void Install()
        {
            Install(applicationProfile.DriverSettings.ApplicationPath);
        }

        public void Background(TimeSpan? timeout = null)
        {
            if (timeout.HasValue)
            {
                localizedLogger.Info("loc.application.background.with.timeout", timeout.Value.TotalSeconds);
                Driver.BackgroundApp(timeout.Value);
            }
            else
            {
                localizedLogger.Info("loc.application.background");
                Driver.BackgroundApp();
            }
        }

        public void Remove(string appId)
        {
            localizedLogger.Info("loc.application.remove", appId);
            Driver.RemoveApp(appId);
        }

        public void Remove()
        {
            Remove(Id);
        }

        public void Activate(string appId, TimeSpan? timeout = null)
        {
            localizedLogger.Info("loc.application.activate", appId);
            if (timeout.HasValue)
            {
                Driver.ActivateApp(appId, timeout.Value);
            }
            else
            {
                Driver.ActivateApp(appId);
            }
        }

        public AppState GetAppState(string appId)
        {
            localizedLogger.Info("loc.application.get.state", appId);
            var state = Driver.GetAppState(appId);
            localizedLogger.Info("loc.application.state", state);
            return state;
        }
    }
}
