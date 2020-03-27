using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebCheckboxTest : UITest, ICheckBoxTest
    {
        private readonly ILabel form = AqualityServices.ElementFactory.GetLabel(By.Id("checkboxes"), "Checkboxes form");

        public ICheckBox GetCheckBox(int number) => 
            AqualityServices.ElementFactory.FindChildElement<ICheckBox>(
                form, By.XPath($".//input[{number}]"), $"#{number}");

        public void OpenCheckBoxesScreen() => 
            AqualityServices.Application.Driver.Url = "http://the-internet.herokuapp.com/checkboxes";

        [Test]
        public void TestCheckBox() => this.InvokeCheckBoxTest();
    }
}
