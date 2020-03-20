using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class TextBox : Element, ITextBox
    {
        private const string LogTyping = "loc.text.typing";
        private const string LogClearing = "loc.text.clearing";
        private const string LogFocusing = "loc.text.focusing";
        private const string LogUnfocusing = "loc.text.unfocusing";

        protected internal TextBox(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        private string LogMaskedValue => LocalizationManager.GetLocalizedMessage("loc.text.masked_value");

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.text.field");

        public string Value => GetAttribute(Attributes.Value);

        public void Clear()
        {
            LogElementAction(LogClearing);
            GetElement().Clear();
        }

        public void ClearAndType(string value)
        {
            ClearAndType(value, maskValueInLog: false);
        }

        public void ClearAndTypeSecret(string value)
        {
            ClearAndType(value, maskValueInLog: true);
        }

        private void ClearAndType(string value, bool maskValueInLog)
        {
            LogElementAction(LogClearing);
            LogElementAction(LogTyping, maskValueInLog ? LogMaskedValue : value);
            DoWithRetry(() => 
            {
                GetElement().Clear();
                GetElement().SendKeys(value);
            });
        }

        public void Focus()
        {
            LogElementAction(LogFocusing);
            DoWithRetry(() => GetElement().SendKeys(string.Empty));
        }

        public void Type(string value)
        {
            Type(value, maskValueInLog: false);
        }

        public void TypeSecret(string value)
        {
            Type(value, maskValueInLog: true);
        }

        private void Type(string value, bool maskValueInLog)
        {
            LogElementAction(LogTyping, maskValueInLog ? LogMaskedValue : value);
            DoWithRetry(() => GetElement().SendKeys(value));
        }

        public void Unfocus()
        {
            LogElementAction(LogUnfocusing);
            DoWithRetry(() => GetElement().SendKeys(Keys.Tab));
        }
    }
}
