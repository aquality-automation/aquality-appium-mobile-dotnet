using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Drawing;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Screens
{
    public abstract class Screen<T> : IScreen
        where T : AppiumDriver<AppiumWebElement>
    {
        private readonly ILabel screenLabel;

        protected Screen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        protected T Driver
        {
            get
            {
                var currentPlatform = AqualityServices.Application.PlatformName;
                if (PlatformName != currentPlatform)
                {
                    throw new InvalidOperationException("Cannot perform this operation. " +
                        $"Current platform {currentPlatform} don't match to target {PlatformName}");
                }

                return (T) AqualityServices.Application.Driver;
            }
        }

        protected abstract PlatformName PlatformName { get; }

        public By Locator { get; }

        public string Name { get; }

        public Size Size => screenLabel.GetElement().Size;

        public IElementStateProvider State => screenLabel.State;

        protected IElementFactory ElementFactory => AqualityServices.ElementFactory;
    }
}
