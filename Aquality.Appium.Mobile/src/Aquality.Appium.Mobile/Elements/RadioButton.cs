using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class RadioButton : CheckableElement, IRadioButton
    {
        protected internal RadioButton(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.radio");
    }
}
