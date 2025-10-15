using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Configurations;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public abstract class ApplicationActivityScreen : AndroidScreen
    {
        private const string Package = "io.appium.android.apis";
        private readonly IButton WaitButton = ElementFactory.GetButton(By.Id("android:id/aerr_wait"), "Wait");
        private readonly IButton CloseAppButton = ElementFactory.GetButton(By.Id("android:id/aerr_close"), "Close app");

        public ApplicationActivityScreen(By locator, string name) : base(locator, name)
        {
        }

        protected abstract string Activity { get; }

        public void Open()
        {
            StartActivity(Package, Activity, stopApp: false);
            // workaround to handle System UI isn't responding dialog
            var result = AqualityServices.ConditionalWait.WaitFor(() =>
            {
                if (!WaitButton.State.WaitForDisplayed())
                {
                    return true;
                }
                WaitButton.Click();
                return WaitButton.State.WaitForNotDisplayed();
            }, AqualityServices.Get<ITimeoutConfiguration>().Command,
            exceptionsToIgnore: [typeof(UnknownErrorException)]);
            if (!result)
            {
                CloseAppButton.Click();
            }
        }
    }
}
