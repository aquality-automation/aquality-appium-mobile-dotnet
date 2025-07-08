using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebRadioButtonTest : UITest, IRadioButtonTest
    {
        public IRadioButton GetRadioButton(int number) => 
            AqualityServices.ElementFactory.Get<IRadioButton>(
                By.XPath($"(//input[@type='radio'])[{number}]"), $"#{number}");

        public void OpenRadioButtonsScreen() => 
            AqualityServices.Application.Driver.Url = "https://formy-project.herokuapp.com/radiobutton";

        [Test]
        public void TestRadioButton() => this.InvokeRadioButtonTest();
    }
}
