using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class CheckBox : CheckableElement, ICheckBox
    {
        protected internal CheckBox(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }
        
        private void SetState(bool value)
        {
            LogElementAction("loc.setting.value", value);
            if (value != GetState())
            {
                Click();
            }
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.checkbox");

        public void Check()
        {
            SetState(true);
        }

        public void Toggle()
        {
            SetState(!GetState());
        }

        public void Uncheck()
        {
            SetState(false);
        }
    }
}
