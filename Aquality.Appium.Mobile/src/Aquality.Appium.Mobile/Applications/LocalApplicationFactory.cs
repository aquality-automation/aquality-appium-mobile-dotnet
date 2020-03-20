using OpenQA.Selenium.Appium.Service;

namespace Aquality.Appium.Mobile.Applications
{
    public class LocalApplicationFactory : ApplicationFactory
    {
        public override IMobileApplication Application
        {
            get
            {
                var service = new AppiumServiceBuilder().WithArguments(AqualityServices.LocalServiceSettings.ServerOptions).Build();
                service.Start();
                var driver = GetDriver(service.ServiceUrl);
                LogApplicationIsReady();
                return new Application(driver, service);
            }
        }
    }
}