using Aquality.Selenium.Core.Applications;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;

namespace Aquality.Appium.Mobile.Applications
{
    /// <summary>
    /// Provides functionality to work with mobile application via Appium driver.  
    /// </summary>
    public interface IMobileApplication : IApplication
    {
        /// <summary>
        /// Provides instance of Appium Driver for current application.
        /// </summary>
        new AppiumDriver Driver { get; }

        /// <summary>
        /// Closes application and disposes <see cref="DriverService"/> if it not null.
        /// </summary>
        void Quit();

        /// <summary>
        /// Provides current AppiumDriver service instance (would be null if driver is not local).
        /// </summary>
        AppiumLocalService DriverService { get; }

        /// <summary>
        /// Provides name of current platform.
        /// </summary>
        PlatformName PlatformName { get; }
    }
}
