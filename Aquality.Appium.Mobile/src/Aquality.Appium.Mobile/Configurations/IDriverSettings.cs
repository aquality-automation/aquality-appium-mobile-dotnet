using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Describes Appium driver settings.
    /// </summary>
    public interface IDriverSettings
    {
        /// <summary>
        /// Gets desired Appium driver options.
        /// </summary>
        AppiumOptions AppiumOptions { get; }

        /// <summary>
        /// Provides a path to the application.
        /// </summary>
        string ApplicationPath { get; }
    }
}