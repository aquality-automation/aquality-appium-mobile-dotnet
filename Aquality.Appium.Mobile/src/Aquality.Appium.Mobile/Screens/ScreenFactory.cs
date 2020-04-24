namespace Aquality.Appium.Mobile.Screens
{
    /// <summary>
    /// Abstract screen factory.
    /// </summary>
    /// <typeparam name="TPlatformScreen">Desired platform screen <see cref="IOSScreen"/> or <see cref="AndroidScreen"/></typeparam>
    public abstract class ScreenFactory<TPlatformScreen> : IScreenFactory
        where TPlatformScreen : class
    {
        /// <summary>
        /// Returns an implementation of a particular app screen.
        /// </summary>
        /// <typeparam name="TAppScreen">Desired application screen.</typeparam>
        public abstract TAppScreen GetScreen<TAppScreen>() where TAppScreen : IScreen;
    }
}
