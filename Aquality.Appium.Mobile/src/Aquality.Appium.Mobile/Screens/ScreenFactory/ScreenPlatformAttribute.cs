using Aquality.Appium.Mobile.Applications;
using System;

namespace Aquality.Appium.Mobile.Screens.ScreenFactory
{
    /// <summary>
    /// Attribute that identifies platform of screen. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScreenPlatformAttribute : Attribute
    {
        public ScreenPlatformAttribute(PlatformName platformName)
        {
            Platform = platformName;
        }

        /// <summary>
        /// Name of platform that screen relates to.
        /// </summary>
        public PlatformName Platform { get; }
    }
}
