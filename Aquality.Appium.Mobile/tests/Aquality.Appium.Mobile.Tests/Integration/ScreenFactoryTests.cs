using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using Aquality.Appium.Mobile.Screens.ScreenFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Aquality.Appium.Mobile.Tests.Integration
{
    public class ScreenFactoryTests
    {
        private const string PlatformNameVariableName = "platformName";
        private const string ScreensLocationVariableName = "screensLocation";

        [Test]
        public void Should_BePossibleTo_GetScreenViaFactory()
        {            
            Assert.That(AqualityServices.ScreenFactory.GetScreen<LoginScreen>() is IScreen);
        }

        [Test]
        public void Should_BePossibleTo_GetAndroidScreenViaFactory()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, "android");
            AqualityServices.SetStartup(new MobileStartup());
            Assert.That(AqualityServices.ScreenFactory.GetScreen<LoginScreen>() is AndroidLoginScreen);
        }

        [Test]
        public void Should_BePossibleTo_GetIOSScreenViaFactory()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, "ios");
            AqualityServices.SetStartup(new MobileStartup());
            Assert.That(AqualityServices.ScreenFactory.GetScreen<LoginScreen>() is IOSLoginScreen);
        }

        [Test]
        public void Should_ThrowInvalidOperationException_OnNotImplementedScreenInterface()
        {
            Assert.Throws<InvalidOperationException>(() => AqualityServices.ScreenFactory.GetScreen<FakeLoginScreen>());
        }

        [Test]
        public void Should_ThrowInvalidOperationException_OnNotValidAssemblyNameWithScreensValue()
        {
            Environment.SetEnvironmentVariable(ScreensLocationVariableName, "Aquality.Fake.Assembly.Tests");            
            AqualityServices.SetStartup(new MobileStartup());
            Assert.Throws<InvalidOperationException>(() => AqualityServices.ScreenFactory.GetScreen<LoginScreen>());
        }

        [TearDown]
        public void CleanUp()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, null);
            Environment.SetEnvironmentVariable(ScreensLocationVariableName, "Aquality.Appium.Mobile.Tests");
            AqualityServices.SetStartup(new MobileStartup());
        }

        public abstract class FakeLoginScreen : Screen
        {
            protected FakeLoginScreen(By locator, string name) : base(locator, name)
            {
            }
        }

        public abstract class LoginScreen : Screen
        {
            protected LoginScreen(By locator, string name) : base(locator, name)
            {
            }
        }

        [ScreenType(PlatformName.Android)]
        public class AndroidLoginScreen : LoginScreen
        {
            public AndroidLoginScreen() : base(By.Id("id"), "name")
            {
            }
        }

        [ScreenType(PlatformName.IOS)]
        public class IOSLoginScreen : LoginScreen
        {
            public IOSLoginScreen() : base(By.Id("id"), "name")
            {
            }
        }
    }
}
