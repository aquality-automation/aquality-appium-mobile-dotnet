namespace Aquality.Appium.Mobile.Screens.ScreenFactory
{
    public interface IScreenFactoryProvider
    {
        /// <summary>
        /// Gets desired ScreenFactory.
        /// </summary>
        IScreenFactory ScreenFactory { get; }
    }
}
