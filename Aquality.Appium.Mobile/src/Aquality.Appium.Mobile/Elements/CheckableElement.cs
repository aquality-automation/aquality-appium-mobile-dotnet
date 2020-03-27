﻿using OpenQA.Selenium;
using ElementState = Aquality.Selenium.Core.Elements.ElementState;

namespace Aquality.Appium.Mobile.Elements
{
    public abstract class CheckableElement : Element
    {
        protected CheckableElement(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public bool IsChecked
        {
            get
            {
                LogElementAction("loc.checkable.is.checked");
                return GetState();
            }
        }

        protected virtual bool GetState()
        {
            return DoWithRetry(() =>
            {
                var checkedAttribute = GetElement().GetAttribute(Attributes.Checked);
                return string.IsNullOrEmpty(checkedAttribute)
                    ? GetElement().Selected
                    : checkedAttribute == "true";

            });
        }
    }
}
