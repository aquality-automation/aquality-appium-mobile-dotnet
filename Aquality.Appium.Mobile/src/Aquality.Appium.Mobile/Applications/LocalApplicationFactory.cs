using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Exceptions;

namespace Aquality.Appium.Mobile.Applications
{
    public class LocalApplicationFactory : ApplicationFactory
    {
        public override IMobileApplication Application
        {
            get
            {
                var service = new AppiumServiceBuilder().WithArguments(AqualityServices.LocalServiceSettings.ServerOptions).Build();
                ActionRetrier.DoWithRetry(service.Start, new [] { typeof(AppiumServerHasNotBeenStartedLocallyException)} );
                var driver = GetDriver(service.ServiceUrl);
                LogApplicationIsReady();
                return new Application(driver, service);
            }
        }
    }
}