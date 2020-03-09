using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    [NonParallelizable]
    public class AndroidWebSessionTest
    {
        private AndroidDriver<AppiumWebElement> driver;

        [SetUp]
        public void SetUp()
        {
            Environment.SetEnvironmentVariable("profile", "androidwebsession");
            AqualityServices.SetStartup(new MobileStartup());
            driver = (AndroidDriver<AppiumWebElement>) AqualityServices.Application.Driver;
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Application.Quit();
        }

        [Test]
        public void CreateWebSession()
        {
            driver.Url = "http://www.google.com";
            var title = driver.Title;
            Assert.AreEqual("Google", title);
        }

        [Test]
        public void TextBoxInteraction()
        {
            driver.Url = "https://wikipedia.org";
            var txbSearch = AqualityServices.ElementFactory.GetTextBox(By.Id("searchInput"), "Search");
            txbSearch.State.WaitForClickable();
            txbSearch.Click();
            // not yet implemented: Assert.IsTrue(driver.isKeyboardShown(), "Keyboard should be shown when click successful");
            txbSearch.Unfocus();
            // not yet implemented: Assert.IsFalse(driver.isKeyboardShown(), "Keyboard should not be shown when unfocus successful");
            txbSearch.Focus();
            // not yet implemented: Assert.assertTrue(driver.isKeyboardShown(), "Keyboard should be shown when focus successful");
            const string valueToSubmit = "quality assurance";
            txbSearch.Type(valueToSubmit);
            Assert.AreEqual(valueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.Clear();
            Assert.AreEqual(string.Empty, txbSearch.Value, "Value should be cleared");
            txbSearch.TypeSecret(valueToSubmit);
            Assert.AreEqual(valueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.ClearAndType(valueToSubmit);
            Assert.AreEqual(valueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.ClearAndTypeSecret(valueToSubmit);
            Assert.AreEqual(valueToSubmit, txbSearch.Value, "Submitted value should match to expected");
            txbSearch.SendKeys(Keys.Enter);
            Assert.IsTrue(txbSearch.State.WaitForNotDisplayed(), "text field should disappear after the submit");
        }
    }
}
