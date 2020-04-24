using Aquality.Appium.Mobile.Applications;
using System;
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
            var type = Assembly.Load(AqualityServices.ApplicationProfile.AssemblyNameWithScreens)
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(TAppScreen)))
                .SingleOrDefault(t => t.IsSubclassOf(typeof(TPlatformScreen)));

            if (type != null)
            {
                return (TAppScreen) Activator.CreateInstance(type);
            }

            throw new ArgumentOutOfRangeException($"Implementation for Screen {typeof(TAppScreen).Name} " +
                $"was not found in Assembly {AqualityServices.ApplicationProfile.AssemblyNameWithScreens}");
        }
    }
}
