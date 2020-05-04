using Aquality.Appium.Mobile.Applications;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Aquality.Appium.Mobile.Screens.ScreenFactory
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
        public TAppScreen GetScreen<TAppScreen>()
            where TAppScreen : IScreen
        {
            Type screenType = null;
            try
            {
                screenType = Assembly.Load(AqualityServices.ApplicationProfile.ScreensLocation)
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(TAppScreen)))
                    .SingleOrDefault(t => t.IsSubclassOf(typeof(TPlatformScreen)));
            } 
            catch (FileNotFoundException ex)
            {
                throw new InvalidOperationException($"Could not find Assembly with Screens. " +
                    $"Please specify value \"screensLocation\" in settings file", ex);
            }
            
            if (screenType == null)
            {
                throw new InvalidOperationException($"Implementation for Screen {typeof(TAppScreen).Name} " +
                    $"was not found in Assembly {AqualityServices.ApplicationProfile.ScreensLocation}");
            }
            return (TAppScreen) Activator.CreateInstance(screenType);
        }
    }
}
