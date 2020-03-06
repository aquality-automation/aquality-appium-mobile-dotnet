using OpenQA.Selenium.Appium.Service;

namespace Aquality.Appium.Mobile.Applications
{
    public class LocalApplicationFactory : ApplicationFactory
    {
        public override IMobileApplication Application
        {
            get
            {
                AppiumLocalService service = AppiumLocalService.BuildDefaultService();
                service.Start();
                var driver = GetDriver(service.ServiceUrl);
                LogApplicationIsReady();
                return new Application(driver, service);
            }
        }
    }
}