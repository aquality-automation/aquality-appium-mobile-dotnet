namespace Aquality.Appium.Mobile.Screens
{
    public interface IScreenFactory
    {
        TAppScreen GetScreen<TAppScreen>() where TAppScreen : IScreen;
    }
}
