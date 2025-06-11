using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public abstract class AndroidScreen : Screen
    {
        protected AndroidScreen(By locator, string name) : base(locator, name)
        {
        }

        /// <summary>
        /// Starts application activity.
        /// </summary>
        /// <param name="appPackage">Package of the target application.</param>
        /// <param name="appActivity">Target activity.</param>
        /// <param name="stopApp">True if need to stop currently running application, false otherwise. True by default.</param>
        protected static void StartActivity(string appPackage, string appActivity, bool stopApp = true)
        {
            AqualityServices.LocalizedLogger.Info("loc.application.android.activity.start", appPackage, appActivity);
            var androidDriver = (AndroidDriver)AqualityServices.Application.Driver;

            var args = new Dictionary<string, object>
            {
                { "intent", $"{appPackage}/{appActivity}"},
                { "stop", stopApp }
            };
            androidDriver.ExecuteScript("mobile: startActivity", args);
            AqualityServices.ConditionalWait.WaitFor(driver => ((AndroidDriver) driver).CurrentActivity == appActivity, message: $"Activity {appActivity} was not started");
        }
    }
}
