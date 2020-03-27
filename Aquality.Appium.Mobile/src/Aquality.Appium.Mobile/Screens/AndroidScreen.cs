using Aquality.Appium.Mobile.Applications;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Aquality.Appium.Mobile.Screens
{
    public class AndroidScreen : Screen<AndroidDriver<AppiumWebElement>>
    {
        protected override PlatformName PlatformName => PlatformName.Android;

        public AndroidScreen(By locator, string name) : base(locator, name)
        {
        }        

        /// <summary>
        /// Starts application activity.
        /// </summary>
        /// <param name="appPackage">Package of the target application.</param>
        /// <param name="appActivity">Target activity.</param>
        /// <param name="stopApp">True if need to stop currently running application, false otherwise. True by default.</param>
        protected void StartActivity(string appPackage, string appActivity, bool stopApp = true)
        {
            AqualityServices.LocalizedLogger.Info("loc.application.android.activity.start", appPackage, appActivity);
            Driver.StartActivity(appPackage, appActivity, stopApp: stopApp);
        }
    }
}
