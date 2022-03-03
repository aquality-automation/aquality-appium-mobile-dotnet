﻿using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Actions;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Core.Visualization;
using Aquality.Selenium.Core.Waitings;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using CoreElement = Aquality.Selenium.Core.Elements.Element;
using IElement = Aquality.Appium.Mobile.Elements.Interfaces.IElement;
using IElementFactory = Aquality.Selenium.Core.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Elements
{
    public abstract class Element : CoreElement, IElement
    {
        protected Element(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public IElementTouchActions TouchActions => new ElementTouchActions(this);

        protected override IElementActionRetrier ActionRetrier => AqualityServices.Get<IElementActionRetrier>();

        protected override IApplication Application => AqualityServices.Application;

        protected override IElementCacheConfiguration CacheConfiguration => AqualityServices.Get<IElementCacheConfiguration>();

        protected override IConditionalWait ConditionalWait => AqualityServices.ConditionalWait;

        protected override IElementFactory Factory => AqualityServices.ElementFactory;

        protected override IElementFinder Finder => AqualityServices.Get<IElementFinder>();

        protected override IImageComparator ImageComparator => AqualityServices.Get<IImageComparator>();

        protected override ILocalizedLogger LocalizedLogger => AqualityServices.LocalizedLogger;

        protected override ILocalizationManager LocalizationManager => AqualityServices.Get<ILocalizationManager>();

        public new AppiumElement GetElement(TimeSpan? timeout = null)
        {
            return (AppiumElement) base.GetElement(timeout);
        }
    }
}
