using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class AlertsMenuScreen : ApplicationActivityScreen
    {
        private readonly IButton twoButtonsDialogButton;
        public AlertsMenuScreen() : base(By.Id("io.appium.android.apis:id/screen"), "Alerts menu")
        {
            twoButtonsDialogButton = ElementFactory.GetButton(By.Id("io.appium.android.apis:id/two_buttons"), "Open two-buttons dialog");
        }

        protected override string Activity => ".app.AlertDialogSamples";

        public void OpenTwoButtonsDialog() => twoButtonsDialogButton.Click();
    }
}
