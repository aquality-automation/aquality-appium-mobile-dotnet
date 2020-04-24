namespace Aquality.Appium.Mobile.Screens
{
    public abstract class ScreenFactory<TPlatformScreen> : IScreenFactory
        where TPlatformScreen : class
    {
        public abstract TAppScreen GetScreen<TAppScreen>() where TAppScreen : IScreen;
    }
}
