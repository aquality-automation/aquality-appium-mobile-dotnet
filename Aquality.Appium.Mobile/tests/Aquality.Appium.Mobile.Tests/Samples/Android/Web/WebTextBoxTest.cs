using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebTextBoxTest : UITest
    {
        private const string ValueToSubmit = "quality assurance";

        [Test]
        public void TextBoxInteraction()
        {
            AqualityServices.Application.Driver.Url = "https://wikipedia.org";
            var txbSearch = AqualityServices.ElementFactory.GetTextBox(By.Id("searchInput"), "Search");
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

        private static void CheckIsKeyboardShown(bool expectedState, string message)
        {
            var waitResult = AqualityServices.ConditionalWait.WaitFor(driver => ((AppiumDriver)driver).IsKeyboardShown() == expectedState,
                message:$"is keyboard shown condition should be {expectedState}");
            Assert.That(AqualityServices.Application.Driver.IsKeyboardShown(), Is.EqualTo(expectedState), message);
        }
    }
}
