using Aquality.Appium.Mobile.Applications;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Aquality.Appium.Mobile.Screens
{
    public class IOSScreen : Screen<IOSDriver<AppiumWebElement>>
    {
        protected override PlatformName PlatformName => PlatformName.IOS;

        public IOSScreen(By locator, string name) : base(locator, name)
        {
        }
    }
}
