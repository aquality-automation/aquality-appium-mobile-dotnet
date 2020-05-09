using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Describes desired device settings.
    /// </summary>
    public interface IDeviceSettings
    {
        /// <summary>
        /// Options (capabilities) related to desired device.
        /// </summary>
        AppiumOptions AppiumOptions { get; }
    }
}
