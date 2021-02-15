using Aquality.Appium.Mobile.Actions;
using System.Drawing;

namespace Aquality.Appium.Mobile.Elements.Actions
{
    public interface IElementTouchActions
    {
        /// <summary>
        /// Swipes from element to end point using TouchAction.
        /// </summary>
        /// <param name="endPoint"> Point on screen to swipe to.</param>
        /// <returns></returns>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">Thrown if element was not found.</exception>
        void Swipe(Point endPoint);

        /// <summary>
        /// Swipes from element to end point using LongPress.
        /// <param name="endPoint"> Point on screen to swipe to.</param>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">Thrown if element was not found.</exception>
        void SwipeWithLongPress(Point endPoint);

        /// <summary>
        /// Scrolls current screen in provided direction until element is displayed.
        /// <param name="direction"> Direction to swipe.</param>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">Thrown if element was not found.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Thrown if incorrect swipe direction was provided.</exception>
        void ScrollToElement(SwipeDirection direction);
    }
}