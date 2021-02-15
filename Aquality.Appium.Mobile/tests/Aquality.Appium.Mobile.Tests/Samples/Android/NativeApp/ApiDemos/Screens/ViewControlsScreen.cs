using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class ViewControlsScreen : ApplicationActivityScreen
    {
        private readonly ILabel lblAllInsideScrollView = ElementFactory.GetLabel(
            MobileBy.AccessibilityId("(And all inside of a ScrollView!)"),
            "All inside of Scroll View");

        private readonly IButton btnDisabled = ElementFactory.GetButton(
            By.Id("button_disabled"),
            "Disabled");

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

        public void ScrollToAllInsideScrollViewLabel() => lblAllInsideScrollView
            .GetTouchActions()
            .ScrollToElement(SwipeDirection.Down);

        public string GetAllInsideScrollViewLabelText() => lblAllInsideScrollView.Text;

        public void ScrollToDisabledButton() => btnDisabled
            .GetTouchActions()
            .ScrollToElement(SwipeDirection.Up);

        public bool IsDisabledButtonClickable() => btnDisabled.State.IsClickable;
    }
}