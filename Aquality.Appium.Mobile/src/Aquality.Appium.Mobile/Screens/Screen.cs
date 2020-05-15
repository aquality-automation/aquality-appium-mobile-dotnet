using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using System.Drawing;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Screens
{
    public abstract class Screen : IScreen
    {
        private readonly ILabel screenLabel;

        protected Screen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        public By Locator { get; }

        public string Name { get; }

        public Size Size => screenLabel.GetElement().Size;

        public IElementStateProvider State => screenLabel.State;

        protected IElementFactory ElementFactory => AqualityServices.ElementFactory;
    }
}
