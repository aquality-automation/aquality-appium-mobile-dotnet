using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Core.Localization;
using OpenQA.Selenium;
using System.Drawing;
using IElement = Aquality.Appium.Mobile.Elements.Interfaces.IElement;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Screens
{
    /// <summary>
    /// Defines base class for any mobile screen.
    /// Use <see cref="ScreenFactory.ScreenTypeAttribute"/> on your screen class to identify platform.
    /// <seealso cref="ScreenFactory.ScreenFactory"/>
    /// </summary>
    public abstract class Screen : Form<IElement>, IScreen
    {
        private readonly ILabel screenLabel;

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="locator">Unique locator of the screen.</param>
        /// <param name="name">Name of the screen.</param>
        protected Screen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        /// <summary>
        /// Gets Screen element defined by its locator and name.
        /// Could be used to find child elements relative to screen element.
        /// </summary>
        protected IElement ScreenElement => screenLabel;
        
        /// <summary>
        /// Element factory <see cref="IElementFactory"/>
        /// </summary>
        protected static IElementFactory ElementFactory => AqualityServices.ElementFactory;

        protected override IVisualizationConfiguration VisualizationConfiguration => AqualityServices.Get<IVisualizationConfiguration>();

        protected override ILocalizedLogger LocalizedLogger => AqualityServices.LocalizedLogger;

        /// <summary>
        /// Locator of the screen.
        /// </summary>
        public By Locator { get; }

        /// <summary>
        /// Name of the screen.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Gets size of form element defined by its locator.
        /// </summary>
        public Size Size => screenLabel.Visual.Size;

        /// <summary>
        /// Provides ability to get screen's state (whether it is displayed, exists or not) and respective waiting functions.
        /// </summary>
        public IElementStateProvider State => screenLabel.State;
    }
}
