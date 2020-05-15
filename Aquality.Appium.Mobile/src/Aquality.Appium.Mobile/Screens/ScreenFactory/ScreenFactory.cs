using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Aquality.Appium.Mobile.Screens.ScreenFactory
{
    /// <summary>
    /// Screen factory.
    /// </summary>
    public class ScreenFactory : IScreenFactory
    {
        private readonly IApplicationProfile applicationProfile;

        public ScreenFactory(IApplicationProfile applicationProfile)
        {
            this.applicationProfile = applicationProfile;
        }

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
                    .Where(t => t.IsSubclassOf(typeof(TAppScreen)))
                    .Where(t => t.IsDefined(typeof(ScreenPlatformAttribute), false))
                    .SingleOrDefault(t => 
                    {
                        var attribute = (ScreenPlatformAttribute) Attribute.GetCustomAttribute(t, typeof(ScreenPlatformAttribute));
                        return attribute.Platform == applicationProfile.PlatformName;
                    });

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
