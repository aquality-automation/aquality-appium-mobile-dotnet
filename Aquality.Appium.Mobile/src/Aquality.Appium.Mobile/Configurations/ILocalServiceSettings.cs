using OpenQA.Selenium.Appium.Service.Options;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Describes Appium local service settings.
    /// </summary>
    public interface ILocalServiceSettings
    {
        /// <summary>
        /// Gets desired Appium local service server options.
        /// </summary>
        OptionCollector ServerOptions { get; }
    }
}