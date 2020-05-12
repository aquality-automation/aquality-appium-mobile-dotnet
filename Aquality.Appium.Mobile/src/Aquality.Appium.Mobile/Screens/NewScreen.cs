using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System.Drawing;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Screens
{
    public class NewScreen : IScreen
    {
        private readonly ILabel screenLabel;

        protected NewScreen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        protected AppiumDriver<AppiumWebElement> Driver
        {
            get
            {
                var currentPlatform = AqualityServices.Application.PlatformName;
                if (currentPlatform == PlatformName.Android)
                {
                    return (AndroidDriver<AppiumWebElement>) AqualityServices.Application.Driver;
                } 
                else
                {
                    return (IOSDriver<AppiumWebElement>) AqualityServices.Application.Driver;
                }
            }
        }

        public By Locator { get; }

        public string Name { get; }

        public Size Size => screenLabel.GetElement().Size;

        public IElementStateProvider State => screenLabel.State;

        protected IElementFactory ElementFactory => AqualityServices.ElementFactory;
    }
}
