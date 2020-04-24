namespace Aquality.Appium.Mobile.Screens
{
    /// <summary>
    /// Interface of abstract screen factory.
    /// </summary>
    public interface IScreenFactory
    {
        /// <summary>
        /// Returns an implementation of a particular app screen.
        /// </summary>
        /// <typeparam name="TAppScreen">Desired application screen.</typeparam>
        TAppScreen GetScreen<TAppScreen>() where TAppScreen : IScreen;
    }
}
