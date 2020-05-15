using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public abstract class ApplicationActivityScreen : AndroidScreen
    {
        private const string Package = "io.appium.android.apis";

        public ApplicationActivityScreen(By locator, string name) : base(locator, name)
        {
        }

        protected abstract string Activity { get; }

        public void Open()
        {
            StartActivity(Package, Activity, stopApp: false);
        }
    }
}
