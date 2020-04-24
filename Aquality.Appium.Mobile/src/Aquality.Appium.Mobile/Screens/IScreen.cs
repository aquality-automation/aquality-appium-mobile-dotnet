using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using System.Drawing;

namespace Aquality.Appium.Mobile.Screens
{
    public interface IScreen 
    {
        By Locator { get; }

        string Name { get; }

        bool IsDisplayed { get; }

        Size Size { get; }

        IElementStateProvider State { get; }
    }
}
