using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Integration.Demo
{
    [Screen(PlatformName.Android)]
    public class AndroidScreen : AbstractScreen
    {
        public AndroidScreen() : base(By.Id(""), "")
        {
        }

        protected override By UsernameTxbLoc => By.Id("");
    }
}
