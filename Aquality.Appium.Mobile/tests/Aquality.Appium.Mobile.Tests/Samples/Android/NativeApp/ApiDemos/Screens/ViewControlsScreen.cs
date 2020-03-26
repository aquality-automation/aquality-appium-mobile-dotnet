using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class ViewControlsScreen : ApplicationActivityScreen
    {
        public ViewControlsScreen() : base(By.Id("android:id/content"), "View/Controls")
        {
        }

        protected override string Activity => ".view.Controls1";
        
        public IRadioButton GetRadioButton(int number) =>
            ElementFactory.GetRadioButton(
                MobileBy.AccessibilityId($"RadioButton {number}"),
                number.ToString());

        public ICheckBox GetCheckBox(int number) =>
            ElementFactory.GetCheckBox(
                MobileBy.AccessibilityId($"Checkbox {number}"),
                number.ToString());
    }
}
