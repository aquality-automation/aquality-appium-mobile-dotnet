using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class RadioButton : Element, IRadioButton
    {
        protected internal RadioButton(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public bool IsChecked => DoWithRetry(() => GetElement().Selected);

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.radio");
    }
}
