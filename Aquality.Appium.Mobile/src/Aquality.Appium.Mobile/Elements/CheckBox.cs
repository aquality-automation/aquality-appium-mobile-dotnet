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

        public override bool IsChecked
        {
            get
            {
                LogElementAction("loc.checkbox.get.state");
                return base.IsChecked;
            }
        }

        private void SetState(bool value)
        {
            LogElementAction("loc.setting.value", value);
            if (value != base.IsChecked)
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
            SetState(!base.IsChecked);
        }

        public void Uncheck()
        {
            SetState(false);
        }
    }
}
