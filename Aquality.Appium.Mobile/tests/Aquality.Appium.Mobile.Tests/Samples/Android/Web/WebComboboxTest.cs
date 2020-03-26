using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Tests.Samples.Android.Web.TheInternet;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebComboboxTest : UITest
    {
        private readonly IComboBox comboBox = AqualityServices.ElementFactory.GetComboBox(By.Id("dropdown"), "dropdown");
        private IEnumerable<DropdownOption> DropdownOptions => Enum.GetValues(typeof(DropdownOption)).Cast<DropdownOption>();

        private By GetChildLocator(string textPart) => By.XPath($".//*[contains(., '{textPart}')]");

        [SetUp]
        public void OpenDropdownPage()
        {
            AqualityServices.Application.Driver.Url = "http://the-internet.herokuapp.Com/dropdown";
            comboBox.State.WaitForClickable();
        }

        [Test]
        public void TestComboBoxGetsTexts() =>
            CollectionAssert.AreEquivalent(
                DropdownOptions.Select(option => option.GetText()),
                comboBox.Texts,
                "Texts should match to expected");

        [Test]
        public void TestComboBoxGetsValues() =>
            CollectionAssert.AreEquivalent(
                DropdownOptions.Select(option => option.GetValue()),
                comboBox.Values,
                "Texts should match to expected");
        [Test]
        public void TestComboBoxSelectionMethods()
        {
            Assert.AreEqual(DropdownOption.Default.GetText(), comboBox.SelectedText, "Option's text mismatch");
            comboBox.SelectByValue(DropdownOption.First.GetValue());
            Assert.AreEqual(DropdownOption.First.GetValue(), comboBox.SelectedValue, "Option's value mismatch");
            comboBox.SelectByText(DropdownOption.Second.GetText());
            Assert.AreEqual(DropdownOption.Second.GetText(), comboBox.SelectedText, "Option's text mismatch");
            comboBox.ClickAndSelectByText(DropdownOption.First.GetText());
            Assert.AreEqual(DropdownOption.First.GetText(), comboBox.SelectedText, "Option's text mismatch");
            comboBox.ClickAndSelectByValue(DropdownOption.Second.GetValue());
            Assert.AreEqual(DropdownOption.Second.GetValue(), comboBox.SelectedValue, "Option's value mismatch");
            comboBox.SelectByContainingText(DropdownOption.First.GetValue());
            Assert.AreEqual(DropdownOption.First.GetText(), comboBox.SelectedText, "Option's text mismatch");
            comboBox.SelectByContainingValue(DropdownOption.Second.GetValue());
            Assert.AreEqual(DropdownOption.Second.GetValue(), comboBox.SelectedValue, "Option's value mismatch");
            comboBox.SelectByIndex(DropdownOption.First.GetIndex());
            Assert.AreEqual(DropdownOption.First.GetText(), comboBox.SelectedText, "Option's text mismatch");
        }

        [Test]
        public void TestFindChildElementWithName()
        {
            Assert.AreEqual(DropdownOption.Second.GetValue(),
                    comboBox.FindChildElement<ILabel>(GetChildLocator(DropdownOption.Second.GetValue()), "2")
                            .GetAttribute("value"),
                    "Child option's value mismatch");
        }

        [Test]
        public void TestFindChildElementWithoutName()
        {
            Assert.AreEqual(DropdownOption.First.GetText(),
                    comboBox.FindChildElement<ILabel>(GetChildLocator(DropdownOption.First.GetText()))
                            .Text,
                    "Child option's text mismatch");
        }
    }
}
