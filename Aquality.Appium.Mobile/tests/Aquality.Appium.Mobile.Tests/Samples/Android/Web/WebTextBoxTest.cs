using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using OpenQA.Selenium;

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
            Assert.AreEqual(ValueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.Clear();
            Assert.AreEqual(string.Empty, txbSearch.Value, "Value should be cleared");
            txbSearch.TypeSecret(ValueToSubmit);
            Assert.AreEqual(ValueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.ClearAndType(ValueToSubmit);
            Assert.AreEqual(ValueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.ClearAndTypeSecret(ValueToSubmit);
            Assert.AreEqual(ValueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.SendKeys(Keys.Enter);
            Assert.IsTrue(txbSearch.State.WaitForNotDisplayed(), "text field should disappear after the submit");
        }

        private static void CheckIsKeyboardShown(bool expectedState, string message)
        {
            // TODO: not yet implemented in dotnet Appium client: http://appium.io/docs/en/commands/device/keys/is-keyboard-shown/
            Assert.AreEqual(expectedState, expectedState, message);
        }
    }
}
