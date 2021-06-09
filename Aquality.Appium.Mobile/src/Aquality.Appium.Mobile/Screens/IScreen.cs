using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Forms;
using OpenQA.Selenium;
using System.Drawing;

namespace Aquality.Appium.Mobile.Screens
{
    /// <summary>
    /// Interface that describes application under the test screen.
    /// </summary>
    public interface IScreen : IForm
    {
        /// <summary>
        /// Unique screen locator.
        /// </summary>
        By Locator { get; }

        /// <summary>
        /// Size of the element described by screen locator.
        /// </summary>
        Size Size { get; }

        /// <summary>
        /// Screen element State.
        /// </summary>
        IElementStateProvider State { get; }
    }
}
