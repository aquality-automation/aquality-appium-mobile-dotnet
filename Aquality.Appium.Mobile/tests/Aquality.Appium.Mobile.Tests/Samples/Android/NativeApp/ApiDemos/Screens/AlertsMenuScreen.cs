using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class AlertsMenuScreen : AndroidScreen
    {
        private readonly IButton twoButtonsDialogButton;
        public AlertsMenuScreen() : base(By.Id("io.appium.android.apis:id/screen"), "Alerts menu")
        {
            twoButtonsDialogButton = ElementFactory.GetButton(By.Id("io.appium.android.apis:id/two_buttons"), "Open two-buttons dialog");
        }

        public void OpenTwoButtonsDialog() => twoButtonsDialogButton.Click();
    }
}
