using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;

namespace Aquality.Appium.Mobile.Screens.ScreenFactory
{
    public class ScreenFactoryProvider : IScreenFactoryProvider
    {
        private readonly IApplicationProfile applicationProfile;

        public ScreenFactoryProvider(IApplicationProfile applicationProfile)
        {
            this.applicationProfile = applicationProfile;
        }

        public IScreenFactory ScreenFactory
        {
            get
            {
                return applicationProfile.PlatformName == PlatformName.Android
                    ? new AndroidScreenFactory()
                    : (IScreenFactory) new IOSScreenFactory();
            }
        }
            
    }
}
