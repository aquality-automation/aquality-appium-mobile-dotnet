using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Aquality.Appium.Mobile.Screens
{
    public class IOSScreen : Screen<IOSDriver<AppiumWebElement>>
    {
        public IOSScreen(By locator, string name) : base(locator, name)
        {
        }
    }
}
