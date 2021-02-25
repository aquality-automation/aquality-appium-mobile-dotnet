using Aquality.Selenium.Core.Configurations;
using System;

namespace Aquality.Appium.Mobile.Configurations
{
    public class TouchActionsSettings : ITouchActionsSettings
    {
        private readonly ISettingsFile settingsFile;
        private readonly string swipeSettingsPath = ".touchActions.swipe";

        public TouchActionsSettings(ISettingsFile settingsFile)
        {
            this.settingsFile = settingsFile;
        }

        public int SwipeRetries => settingsFile.GetValue<int>($"{swipeSettingsPath}.retries");

        public TimeSpan SwipeDuration => TimeSpan.FromSeconds(settingsFile.GetValue<long>($"{swipeSettingsPath}.duration"));

        public double SwipeVerticalOffset => settingsFile.GetValue<double>($"{swipeSettingsPath}.verticalOffset");

        public double SwipeHorizontalOffset => settingsFile.GetValue<double>($"{swipeSettingsPath}.horizontalOffset");
    }
}
