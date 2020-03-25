using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class TwoButtonsAlert : AndroidScreen
    {
        private static readonly By AlertTitleLocator = By.Id("android:id/alertTitle");

        private ILabel AlertTitleLabel => ElementFactory.GetLabel(AlertTitleLocator, "Alert title");

        private IButton CloseButton => ElementFactory.GetButton(By.Id("android:id/button1"), "Close alert dialog");

        public TwoButtonsAlert() : base(AlertTitleLocator, "Two-buttons alert")
        {
        }

        public string AlertText => AlertTitleLabel.Text;

        public void Close() => CloseButton.Click();
    }
}
