using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public abstract class ApplicationActivityScreen : AndroidScreen
    {
        private const string Package = "io.appium.android.apis";
        private readonly IButton WaitButton = ElementFactory.GetButton(By.Id("android:id/aerr_wait"), "Wait");

        public ApplicationActivityScreen(By locator, string name) : base(locator, name)
        {
        }

        protected abstract string Activity { get; }

        public void Open()
        {
            StartActivity(Package, Activity, stopApp: false);

            // workaround to handle System UI isn't responding dialog            
            if (WaitButton.State.WaitForDisplayed())
            {
                WaitButton.Click();
                WaitButton.State.WaitForNotDisplayed();
            }
        }
    }
}
