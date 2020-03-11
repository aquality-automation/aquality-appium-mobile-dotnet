using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Applications
{
    public class LocalApplicationFactory : ApplicationFactory
    {
        public override IMobileApplication Application
        {
            get
            {
                var optionsCollector = new OptionCollector().AddArguments(new KeyValuePair<string, string>("--allow-insecure", "chromedriver_autodownload"));
                var service = new AppiumServiceBuilder().WithArguments(optionsCollector).Build();
                service.Start();
                var driver = GetDriver(service.ServiceUrl);
                LogApplicationIsReady();
                return new Application(driver, service);
            }
        }
    }
}