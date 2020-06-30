using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Core.Waitings;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using CoreElement = Aquality.Selenium.Core.Elements.Element;
using IElementFactory = Aquality.Selenium.Core.Elements.Interfaces.IElementFactory;
using IElement = Aquality.Appium.Mobile.Elements.Interfaces.IElement;

namespace Aquality.Appium.Mobile.Elements
{
    public abstract class Element : CoreElement, IElement
    {
        protected Element(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        protected override IElementActionRetrier ActionRetrier => AqualityServices.Get<IElementActionRetrier>();

        protected override IApplication Application => AqualityServices.Application;

        protected override IElementCacheConfiguration CacheConfiguration => AqualityServices.Get<IElementCacheConfiguration>();

        protected override IConditionalWait ConditionalWait => AqualityServices.ConditionalWait;

        protected override IElementFactory Factory => AqualityServices.ElementFactory;

        protected override IElementFinder Finder => AqualityServices.Get<IElementFinder>();

        protected override ILocalizedLogger LocalizedLogger => AqualityServices.LocalizedLogger;

        protected override ILocalizationManager LocalizationManager => AqualityServices.Get<ILocalizationManager>();

        public new AppiumWebElement GetElement(TimeSpan? timeout = null)
        {
            return (AppiumWebElement) base.GetElement(timeout);
        }
    }
}
