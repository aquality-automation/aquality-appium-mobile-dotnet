using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
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
            driver.Navigate().GoToUrl("http://www.google.com");
            var title = driver.Title;
            Assert.AreEqual("Google", title);
        }
    }
}
