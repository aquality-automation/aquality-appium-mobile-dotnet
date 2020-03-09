using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Elements
{
    public class ComboBox : Element, IComboBox
    {
        private const string LogSelectingValue = "loc.combobox.select.by.value";
        protected internal ComboBox(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public string SelectedText => DoWithRetry(() => new SelectElement(GetElement()).SelectedOption.Text);

        public string SelectedValue => DoWithRetry(() => new SelectElement(GetElement()).SelectedOption.GetAttribute(Attributes.Value));

        public IList<string> Texts
        {
            get
            {
                LogElementAction("loc.combobox.get.texts");
                return DoWithRetry(
                    () => new SelectElement(GetElement())
                    .Options.Select(option => option.Text).ToList());
            }
        }

        public IList<string> Values
        {
            get
            {
                LogElementAction("loc.combobox.get.values");
                return DoWithRetry(
                    () => new SelectElement(GetElement())
                    .Options.Select(option => option.GetAttribute(Attributes.Value)).ToList());
            }
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.combobox");

        public void ClickAndSelectByText(string text)
        {
            Click();
            SelectByText(text);
        }

        public void ClickAndSelectByValue(string value)
        {
            Click();
            SelectByValue(value);
        }

        public void SelectByContainingText(string text)
        {
            LogElementAction(LogSelectingValue, text);
            SelectOptionThatContains(element => element.Text, 
                (element, value) => element.SelectByText(value), 
                text);
        }

        public void SelectByContainingValue(string value)
        {
            LogElementAction(LogSelectingValue, value);
            SelectOptionThatContains(element => element.GetAttribute(Attributes.Value),
                (element, val) => element.SelectByValue(val),
                value);
        }

        private void SelectOptionThatContains(Func<IWebElement, string> getValueFunction, 
            Action<SelectElement, string> selectAction, string value)
        {
            DoWithRetry(() => 
            {
                var select = new SelectElement(GetElement());
                var elements = select.Options;
                var isSelected = false;
                foreach (var element in elements)
                {
                    var currentValue = getValueFunction(element);
                    Logger.Debug(currentValue);
                    if (currentValue.ToLower().Contains(value.ToLower()))
                    {
                        selectAction(select, currentValue);
                        isSelected = true;
                    }
                }
                if (!isSelected)
                {
                    throw new InvalidElementStateException(
                        string.Format(LocalizationManager.GetLocalizedMessage(
                            "loc.combobox.impossible.to.select.contain.value.or.text"), value, Name));
                }
            });
        }

        public void SelectByIndex(int index)
        {
            LogElementAction(LogSelectingValue, $"#{index}");
            DoWithRetry(() => new SelectElement(GetElement()).SelectByIndex(index));
        }

        public void SelectByText(string text)
        {
            LogElementAction(LogSelectingValue, text);
            DoWithRetry(() => new SelectElement(GetElement()).SelectByText(text));
        }

        public void SelectByValue(string value)
        {
            LogElementAction(LogSelectingValue, value);
            DoWithRetry(() => new SelectElement(GetElement()).SelectByValue(value));
        }
    }
}
