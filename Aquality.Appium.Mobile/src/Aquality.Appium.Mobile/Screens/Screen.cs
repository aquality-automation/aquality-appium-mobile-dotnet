﻿using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Drawing;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Screens
{
    public abstract class Screen<T> where T : AppiumDriver<AppiumWebElement>
    {
        private readonly ILabel screenLabel;

        protected Screen(By locator, string name)
        {
            Locator = locator;
            Name = name;
            screenLabel = ElementFactory.GetLabel(locator, name);
        }

        public T Driver => (T) AqualityServices.Application.Driver;

        public By Locator { get; }

        public string Name { get; }

        public bool IsDisplayed => State.WaitForDisplayed();

        public Size Size => screenLabel.GetElement().Size;

        public IElementStateProvider State => screenLabel.State;

        protected IElementFactory ElementFactory => AqualityServices.ElementFactory;
    }
}