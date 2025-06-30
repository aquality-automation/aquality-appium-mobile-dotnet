using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using System;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp
{
    public class AndroidApplicationManagementTest : UITest
    {
        [TearDown]
        public void TearDown()
        {
            QuitApp();
        }

        [Test, Retry(5)]
        public void ApplicationManagement()
        {
            var app = AqualityServices.Application;
            Assert.Throws<ArgumentException>(() => AqualityServices.ApplicationProfile.DriverSettings.BundleId.GetType());
            new InvokeSearchScreen().Open(); 
            var id = app.Id;
            Assert.DoesNotThrow(() => app.Background());
            Assert.That(app.GetState(id), Is.EqualTo(AppState.RunningInBackground).Or.EqualTo(AppState.RunningInBackgroundOrSuspended));
            Assert.DoesNotThrow(() => app.Activate(id));
            Assert.That(app.GetState(id), Is.EqualTo(AppState.RunningInForeground));
            Assert.DoesNotThrow(() => app.Terminate());
            Assert.That(app.IsStarted, Is.True);
            Assert.That(app.GetState(id), Is.EqualTo(AppState.NotRunning));
            Assert.DoesNotThrow(() => app.Remove(id));
            Assert.That(app.GetState(id), Is.EqualTo(AppState.NotInstalled));
            Assert.DoesNotThrow(app.Install);
            Assert.That(app.GetState(id), Is.EqualTo(AppState.NotRunning));
        }
    }
}
