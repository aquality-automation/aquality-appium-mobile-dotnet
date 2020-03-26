using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using System;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web
{
    [SetUpFixture]
    public class AndroidWebTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Environment.SetEnvironmentVariable("profile", "androidwebsession");
            AqualityServices.SetStartup(new MobileStartup());
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Environment.SetEnvironmentVariable("profile", null);
            AqualityServices.SetStartup(new MobileStartup());
        }
    }
}
