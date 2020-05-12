using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Integration.Demo
{
    [Screen(PlatformName.IOS)]
    public class IOSScreen : AbstractScreen
    {
        public IOSScreen() : base(By.Id(""), "")
        {
        }

        protected override By UsernameTxbLoc => By.Id("");
    }
}
