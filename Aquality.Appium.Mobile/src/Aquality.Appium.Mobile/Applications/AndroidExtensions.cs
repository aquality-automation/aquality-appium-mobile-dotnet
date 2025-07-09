using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Applications
{
    /// <summary>
    /// Extensions for Android applications
    /// </summary>
    public static class AndroidExtensions
    {
        /// <summary>
        /// Starts application activity.
        /// </summary>
        /// <param name="application">Android application</param>
        /// <param name="appPackage">Package of the target application.</param>
        /// <param name="appActivity">Target activity.</param>
        /// <param name="stopApp">True if need to stop currently running application, false otherwise. True by default.</param>
        public static void StartActivity(this IMobileApplication application, string appPackage, string appActivity, bool stopApp = true)
        {
            AqualityServices.LocalizedLogger.Info("loc.application.android.activity.start", appPackage, appActivity);
            var args = new Dictionary<string, object>
            {
                { "intent", $"{appPackage}/{appActivity}"},
                { "stop", stopApp }
            };
            application.ExecuteScript("mobile: startActivity", args);
            AqualityServices.ConditionalWait.WaitFor(driver => ((AndroidDriver)driver).CurrentActivity == appActivity, message: $"Activity {appActivity} was not started");
        }
    }
}
