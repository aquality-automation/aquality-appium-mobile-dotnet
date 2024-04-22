using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class WebLinkTest : UITest
    {
        private readonly ILink link = AqualityServices.ElementFactory
            .GetLink(By.Id("content"), "Content")
            .FindChildElement<ILink>(By.Id("redirect"));

        [SetUp]
        public void OpenLinkPage() =>
            AqualityServices.Application.Driver.Url = "http://the-internet.herokuapp.com/redirector";

        [Test]
        public void TestLinkGetsHref() =>
            Assert.That(link.Href.Contains("redirect"), Is.True, "Link href mismatch");

        [Test]
        public void TestLinkClickable()
        {
            link.State.WaitForClickable();
            link.Click();
            Assert.That(link.State.WaitForNotExist(), Is.True, "Link was not clicked properly as it isn't disappeared");
        }
    }
}
