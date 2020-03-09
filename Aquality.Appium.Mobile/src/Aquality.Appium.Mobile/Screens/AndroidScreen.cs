using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Aquality.Appium.Mobile.Screens
{
    public class AndroidScreen : Screen<AndroidDriver<AppiumWebElement>>
    {
        public AndroidScreen(By locator, string name) : base(locator, name)
        {
        }
    }
}
