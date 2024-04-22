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
        private static IEnumerable<DropdownOption> DropdownOptions => Enum.GetValues(typeof(DropdownOption)).Cast<DropdownOption>();

        private static By GetChildLocator(string textPart) => By.XPath($".//*[contains(., '{textPart}')]");

        [SetUp]
        public void OpenDropdownPage()
        {
            AqualityServices.Application.Driver.Url = "http://the-internet.herokuapp.Com/dropdown";
            comboBox.State.WaitForClickable();
        }

        [Test]
        public void TestComboBoxGetsTexts() =>
            Assert.That(
                comboBox.Texts,
                Is.EquivalentTo(DropdownOptions.Select(option => option.GetText())),                
                "Texts should match to expected");

        [Test]
        public void TestComboBoxGetsValues() =>
            Assert.That(
                comboBox.Values,
                Is.EquivalentTo(DropdownOptions.Select(option => option.GetValue())),
                "Texts should match to expected");
        [Test]
        public void TestComboBoxSelectionMethods()
        {
            Assert.That(comboBox.SelectedText, Is.EqualTo(DropdownOption.Default.GetText()), "Option's text mismatch");
            comboBox.SelectByValue(DropdownOption.First.GetValue());
            Assert.That(comboBox.SelectedValue, Is.EqualTo(DropdownOption.First.GetValue()), "Option's value mismatch");
            comboBox.SelectByText(DropdownOption.Second.GetText());
            Assert.That(comboBox.SelectedText, Is.EqualTo(DropdownOption.Second.GetText()), "Option's text mismatch");
            comboBox.ClickAndSelectByText(DropdownOption.First.GetText());
            Assert.That(comboBox.SelectedText, Is.EqualTo(DropdownOption.First.GetText()), "Option's text mismatch");
            comboBox.ClickAndSelectByValue(DropdownOption.Second.GetValue());
            Assert.That(comboBox.SelectedValue, Is.EqualTo(DropdownOption.Second.GetValue()), "Option's value mismatch");
            comboBox.SelectByContainingText(DropdownOption.First.GetValue());
            Assert.That(comboBox.SelectedText, Is.EqualTo(DropdownOption.First.GetText()), "Option's text mismatch");
            comboBox.SelectByContainingValue(DropdownOption.Second.GetValue());
            Assert.That(comboBox.SelectedValue, Is.EqualTo(DropdownOption.Second.GetValue()), "Option's value mismatch");
            comboBox.SelectByIndex(DropdownOption.First.GetIndex());
            Assert.That(comboBox.SelectedText, Is.EqualTo(DropdownOption.First.GetText()), "Option's text mismatch");
        }

        [Test]
        public void TestFindChildElementWithName()
        {
            Assert.That(
                    comboBox.FindChildElement<ILabel>(GetChildLocator(DropdownOption.Second.GetValue()), "2")
                            .GetAttribute("value"),
                    Is.EqualTo(DropdownOption.Second.GetValue()),
                    "Child option's value mismatch");
        }

        [Test]
        public void TestFindChildElementWithoutName()
        {
            Assert.That(
                comboBox.FindChildElement<ILabel>(GetChildLocator(DropdownOption.First.GetText())).Text, 
                Is.EqualTo(DropdownOption.First.GetText()), 
                "Child option's text mismatch");
        }
    }
}
