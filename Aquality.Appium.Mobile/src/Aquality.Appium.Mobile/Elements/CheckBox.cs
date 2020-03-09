using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class CheckBox : Element, ICheckBox
    {
        protected internal CheckBox(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public bool IsChecked
        {
            get
            {
                LogElementAction("loc.checkbox.get.state");
                return GetElement().Selected;
            }
            private set
            {
                LogElementAction("loc.setting.value", value);
                if (value != IsChecked)
                {
                    Click();
                }
            }
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.checkbox");

        public void Check()
        {
            IsChecked = true;
        }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }

        public void Uncheck()
        {
            IsChecked = false;
        }
    }
}
