using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Aquality.Appium.Mobile.Tests.Integration
{
    public class ScreenFactoryTests
    {
        private const string PlatformNameVariableName = "platformName";
        private const string AssemblyNameWithScreensVariableName = "assemblyNameWithScreens";

        [Test]
        public void Should_BePossibleTo_GetScreenViaFactory()
        {            
            Assert.That(AqualityServices.ScreenFactory.GetScreen<ILoginScreen>() is IScreen);
        }

        [Test]
        public void Should_BePossibleTo_GetAndroidScreenViaFactory()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, "android");
            AqualityServices.SetStartup(new MobileStartup());
            Assert.That(AqualityServices.ScreenFactory.GetScreen<ILoginScreen>() is AndroidScreen);
        }

        [Test]
        public void Should_BePossibleTo_GetIOSScreenViaFactory()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, "ios");
            AqualityServices.SetStartup(new MobileStartup());
            Assert.That(AqualityServices.ScreenFactory.GetScreen<ILoginScreen>() is IOSScreen);
        }

        [Test]
        public void Should_ThrowInvalidOperationException_OnNotImplementedScreenInterface()
        {
            Assert.Throws<InvalidOperationException>(() => AqualityServices.ScreenFactory.GetScreen<IFakeLoginScreen>());
        }

        [Test]
        public void Should_ThrowInvalidOperationException_OnNotValidAssemblyNameWithScreensValue()
        {
            Environment.SetEnvironmentVariable(AssemblyNameWithScreensVariableName, "Aquality.Fake.Assembly.Tests");            
            AqualityServices.SetStartup(new MobileStartup());
            Assert.Throws<InvalidOperationException>(() => AqualityServices.ScreenFactory.GetScreen<ILoginScreen>());
        }

        [TearDown]
        public void CleanUp()
        {
            Environment.SetEnvironmentVariable(PlatformNameVariableName, null);
            Environment.SetEnvironmentVariable(AssemblyNameWithScreensVariableName, "Aquality.Appium.Mobile.Tests");
            AqualityServices.SetStartup(new MobileStartup());
        }

        public interface IFakeLoginScreen : IScreen
        {
        }

        public interface ILoginScreen : IScreen
        {
        }

        public class AndroidLoginScreen : AndroidScreen, ILoginScreen
        {
            public AndroidLoginScreen() : base(By.Id("id"), "name")
            {
            }
        }

        public class IOSLoginScreen : IOSScreen, ILoginScreen
        {
            public IOSLoginScreen() : base(By.Id("id"), "name")
            {
            }
        }
    }
}
