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
    public abstract class Screen<T> where T : AppiumDriver<AppiumWebElement>
    {
        protected abstract PlatformName PlatformName { get; }

        private readonly ILabel screenLabel;

        protected Screen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        public T Driver
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

        public By Locator { get; }

        public string Name { get; }

        public bool IsDisplayed => State.WaitForDisplayed();

        public Size Size => screenLabel.GetElement().Size;

        public IElementStateProvider State => screenLabel.State;

        protected IElementFactory ElementFactory => AqualityServices.ElementFactory;
    }
}
