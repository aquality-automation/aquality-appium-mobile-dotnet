using Aquality.Appium.Mobile.Applications;
using NUnit.Framework;
using System.IO;

namespace Aquality.Appium.Mobile.Tests.Samples
{
    public abstract class UITest
    {
        private const string TestResultsScreenshot = "final_screen.png";

        [TearDown]
        public void AddScreenshot()
        {
            if (AqualityServices.IsApplicationStarted)
            {
                File.WriteAllBytes(TestResultsScreenshot, AqualityServices.Application.Driver.GetScreenshot().AsByteArray);
                TestContext.AddTestAttachment(TestResultsScreenshot);
            }
        }

        protected void QuitApp()
        {
            if (AqualityServices.IsApplicationStarted)
            {
                AqualityServices.Application.Quit();
            }
        }
    }
}
