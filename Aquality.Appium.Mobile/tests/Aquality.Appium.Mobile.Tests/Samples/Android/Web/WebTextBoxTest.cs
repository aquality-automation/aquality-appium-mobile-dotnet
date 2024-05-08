using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Configurations;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebTextBoxTest : UITest
    {
        private const string ValueToSubmit = "quality assurance";
        private readonly ITextBox txbSearch = AqualityServices.ElementFactory.GetTextBox(By.Id("searchInput"), "Search");
            

        [Test]
        public void TextBoxInteraction()
        {
            AqualityServices.Application.Driver.Url = "https://wikipedia.org";
            txbSearch.State.WaitForClickable();
            txbSearch.Click();
            CheckIsKeyboardShown(expectedState: true, "Keyboard should be shown when click successful");
            txbSearch.Unfocus();
            CheckIsKeyboardShown(expectedState: false, "Keyboard should not be shown when unfocus successful");
            txbSearch.Focus();
            CheckIsKeyboardShown(expectedState: true, "Keyboard should be shown when focus successful");
            txbSearch.Type(ValueToSubmit);
            Assert.That(txbSearch.Value, Is.EqualTo(ValueToSubmit), "Submitted value should match to expected");
            txbSearch.Clear();
            Assert.That(txbSearch.Value, Is.EqualTo(string.Empty), "Value should be cleared");
            txbSearch.TypeSecret(ValueToSubmit);
            Assert.That(txbSearch.Value, Is.EqualTo(ValueToSubmit), "Submitted value should match to expected");
            txbSearch.ClearAndType(ValueToSubmit);
            Assert.That(txbSearch.Value, Is.EqualTo(ValueToSubmit), "Submitted value should match to expected");
            txbSearch.ClearAndTypeSecret(ValueToSubmit);
            Assert.That(txbSearch.Value, Is.EqualTo(ValueToSubmit), "Submitted value should match to expected");
            txbSearch.SendKeys(Keys.Enter);
            Assert.That(txbSearch.State.WaitForNotDisplayed(), Is.True, "text field should disappear after the submit");
        }

        private void CheckIsKeyboardShown(bool expectedState, string message)
        {
            var driver = AqualityServices.Application.Driver;
            var timeoutConfig = AqualityServices.Get<ITimeoutConfiguration>();
            var waitResult = AqualityServices.ConditionalWait.WaitFor(() => driver.IsKeyboardShown() == expectedState,
                timeout: timeoutConfig.Command,
                pollingInterval: timeoutConfig.PollingInterval.Multiply(10));
            if (!waitResult && expectedState)
            {
                txbSearch.Click();
            }
            Assert.That(driver.IsKeyboardShown(), Is.EqualTo(expectedState), message);
        }
    }
}
