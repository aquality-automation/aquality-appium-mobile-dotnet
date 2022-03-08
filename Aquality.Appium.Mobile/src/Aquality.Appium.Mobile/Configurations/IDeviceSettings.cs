using OpenQA.Selenium.Appium;
using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Describes desired device settings.
    /// </summary>
    public interface IDeviceSettings
    {
        /// <summary>
        /// Capabilities related to desired device.
        /// </summary>
        IReadOnlyDictionary<string, object> Capabilities { get; }
    }
}
