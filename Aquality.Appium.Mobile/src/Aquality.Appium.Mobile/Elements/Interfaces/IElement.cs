using OpenQA.Selenium;
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
        /// <returns></returns>
        /// <exception cref="NoSuchElementException">Thrown if element was not found.</exception>
        new AppiumWebElement GetElement(TimeSpan? timeout = null);
    }
}
