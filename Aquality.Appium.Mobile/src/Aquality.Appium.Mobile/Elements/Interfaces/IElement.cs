using Aquality.Appium.Mobile.Elements.Actions;
using OpenQA.Selenium.Appium;
using System;
using CoreElement = Aquality.Selenium.Core.Elements.Interfaces.IElement;

namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface IElement : CoreElement
    {
        /// <summary>
        /// Gets current mobile element by specified <see cref="CoreElement.Locator"/>
        /// </summary>
        /// <param name="timeout">Timeout for waiting (would use default timeout from settings by default).</param>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">Thrown if element was not found.</exception>
        new AppiumWebElement GetElement(TimeSpan? timeout = null);

        /// <summary>
        /// Utility used to perform touch actions for element
        /// </summary>
        IElementTouchActions TouchActions { get; }
    }
}
