using Aquality.Selenium.Core.Configurations;

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

        public long SwipeDuration => settingsFile.GetValue<long>($"{swipeSettingsPath}.duration");

        public float SwipeVerticalOffset => settingsFile.GetValue<float>($"{swipeSettingsPath}.verticalOffset");

        public float SwipeHorizontalOffset => settingsFile.GetValue<float>($"{swipeSettingsPath}.horizontalOffset");
    }
}