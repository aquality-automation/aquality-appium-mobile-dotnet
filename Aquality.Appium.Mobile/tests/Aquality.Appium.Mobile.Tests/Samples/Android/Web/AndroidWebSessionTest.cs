using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    public class AndroidWebSessionTest : UITest
    {
        private IWebDriver Driver => AqualityServices.Application.Driver;

        [Test]
        public void CreateWebSession()
        {
            Driver.Url = "http://www.google.com";
            var title = Driver.Title;
            Assert.AreEqual("Google", title);
        }
    }
}
