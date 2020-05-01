using Aquality.Appium.Mobile.Applications;
using System;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Describes application settings.
    /// </summary>
    public interface IApplicationProfile
    {
        /// <summary>
        /// Gets Appium driver settings for application.
        /// </summary>
        IDriverSettings DriverSettings { get; }

        /// <summary>
        /// Is remote Appium service or not: true to use <see cref="RemoteConnectionUrl"/> 
        /// and false to create default <see cref="OpenQA.Selenium.Appium.Service.AppiumLocalService"/>.
        /// </summary>
        bool IsRemote { get; }

        /// <summary>
        /// Gets name of current application platform.
        /// </summary>
        PlatformName PlatformName { get; }

        /// <summary>
        /// Gets remote connection URI is case of remote browser.
        /// </summary>
        Uri RemoteConnectionUrl { get; }

        /// <summary>
        /// Gets name of Assembly with screens for ScreenFactory.
        /// </summary>
        string AssemblyNameWithScreens { get; }
    }
}
