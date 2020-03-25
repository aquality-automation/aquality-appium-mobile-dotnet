using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class MainMenuScreen : AndroidScreen
    {
        private const string SearchActivity = ".app.SearchInvoke";
        private const string AlertDialogActivity = ".app.AlertDialogSamples";
        private const string Package = "io.appium.android.apis";

        public MainMenuScreen() : base(By.Id("android:id/content"), "Main menu")
        {
        }

        public void StartSearch() => Driver.StartActivity(Package, SearchActivity);

        public void OpenAlerts() => Driver.StartActivity(Package, AlertDialogActivity);
    }
}
