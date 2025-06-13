using Aquality.Selenium.Core.Applications;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;

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
        /// Execute application script
        /// </summary>
        /// <param name="script">script</param>
        /// <param name="args">parameters</param>
        /// <returns></returns>
        object ExecuteScript(string script, Dictionary<string, object> args = null);

        /// <summary>
        /// Quits application driver and disposes <see cref="DriverService"/> if it not null.
        /// </summary>
        void Quit();

        /// <summary>
        /// Installs an application.
        /// </summary>
        /// <param name="appPath">a string containing the file path or url of the application.</param>
        void Install(string appPath);

        /// <summary>
        /// Installs an application defined in settings.
        /// Note that path to the application must be defined as 'app' capability.
        /// </summary>
        void Install();

        /// <summary>
        /// Send the currently active application to the background, 
        /// and either return after a certain amount of time, or leave the application deactivated
        /// (as "Home" button does).
        /// <param name="timeout">How long to background the application for. If null, application would be deactivated entirely.</param>
        /// </summary>
        void Background(TimeSpan? timeout = null);

        /// <summary>
        /// Removes an application.
        /// </summary>
        /// <param name="appId">the bundle identifier (or appId) of the application to be removed.</param>
        void Remove(string appId);

        /// <summary>
        /// Removes currently running application.
        /// </summary>
        void Remove();

        /// <summary>
        /// Activates the given application by moving to the foreground if it is running in the background
        /// or starting it if it is not running yet.
        /// </summary>
        /// <param name="appId">the bundle identifier (or appId) of the application.</param>
        /// <param name="timeout">command timeout.</param>
        void Activate(string appId, TimeSpan? timeout = null);

        /// <summary>
        /// Terminate the particular application if it is running.
        /// </summary>
        /// <param name="appId">the bundle identifier (or appId) of the application to be terminated.</param>
        /// <param name="timeout">If not null, defines for how long to wait until the application is terminated.</param>
        /// <returns>true if the application was running before and has been successfully stopped.</returns>
        bool Terminate(string appId, TimeSpan? timeout = null);

        /// <summary>
        /// Terminates currently running application.
        /// </summary>
        /// <param name="timeout">If not null, defines for how long to wait until the application is terminated.</param>
        /// <returns>true if the application was running before and has been successfully stopped.</returns>
        bool Terminate(TimeSpan? timeout = null);

        /// <summary>
        /// Gets the state of the application.
        /// </summary>
        /// <param name="appId">the bundle identifier (or appId) of the application.</param>
        /// <returns>an enumeration of the application state.</returns>
        AppState GetState(string appId);

        /// <summary>
        /// Provides current AppiumDriver service instance (would be null if driver is not local).
        /// </summary>
        AppiumLocalService DriverService { get; }

        /// <summary>
        /// Provides name of current platform.
        /// </summary>
        PlatformName PlatformName { get; }

        /// <summary>
        /// Gets the bundle identifier (or appId) of the currently running application.
        /// </summary>
        string Id { get; }
    }
}
