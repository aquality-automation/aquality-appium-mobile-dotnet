using OpenQA.Selenium.Remote;

namespace Aquality.Appium.Mobile.Applications
{
    public class RemoteApplicationFactory : ApplicationFactory
    {
        public override IMobileApplication Application
        {
            get
            {
                var serverUrl = AqualityServices.ApplicationProfile.RemoteConnectionUrl;
                var driver = GetDriver(serverUrl);
                driver.FileDetector = new LocalFileDetector();
                LogApplicationIsReady();
                return new Application(driver);
            }
        }
    }
}
