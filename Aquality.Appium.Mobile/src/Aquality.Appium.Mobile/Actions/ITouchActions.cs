using System.Drawing;

namespace Aquality.Appium.Mobile.Actions
{
    public interface ITouchActions
    {
        /// <summary>
        /// Swipes from start point to end point using TouchAction.
        /// </summary>
        /// <param name="startPoint">Point on screen to swipe from.</param>
        /// <param name="endPoint">Point on screen to swipe to.</param>
        void Swipe(Point startPoint, Point endPoint);

        /// <summary>
        /// Performs long press action and moves cursor from a start point to an end point imitating the swipe action.
        /// </summary>
        /// <param name="startPoint">Point on screen to swipe from.</param>
        /// <param name="endPoint">Point on screen to swipe to.</param>
        void SwipeWithLongPress(Point startPoint, Point endPoint);
    }
}
