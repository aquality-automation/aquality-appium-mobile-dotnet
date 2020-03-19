using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service.Options;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Configurations
{
    public class LocalServiceSettings : ILocalServiceSettings
    {
        private readonly ISettingsFile settingsFile;
     
        public LocalServiceSettings(ISettingsFile settingsFile)
        {
            this.settingsFile = settingsFile;
        }

        private string ServiceSettingsPath => $".localServiceSettings";

        protected IDictionary<string, object> Capabilities => settingsFile.GetValueOrNew<Dictionary<string, object>>($"{ServiceSettingsPath}.{nameof(Capabilities).ToLower()}");

        protected IDictionary<string, string> Arguments => settingsFile.GetValueOrNew<Dictionary<string, string>>($"{ServiceSettingsPath}.{nameof(Arguments).ToLower()}");
        
        protected virtual AppiumOptions AppiumOptions
        {
            get
            {
                var options = new AppiumOptions();
                Capabilities.ToList().ForEach(capability => options.AddAdditionalCapability(capability.Key, capability.Value));
                return options;
            }
        }
        
        public OptionCollector ServerOptions
        {
            get
            {
                var options = new OptionCollector();
                Arguments.ToList().ForEach(argumentPair => options.AddArguments(argumentPair));
                options.AddCapabilities(AppiumOptions);
                return options;
            }
        }
    }
}
