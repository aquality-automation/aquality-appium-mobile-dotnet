using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Drawing;

namespace Aquality.Appium.Mobile.Actions
{
    public class TouchActions : ITouchActions
    {
        public void Swipe(Point startPoint, Point endPoint)
        {
            AqualityServices.LocalizedLogger.Info(
                "loc.action.swipe",
                startPoint.X,
                startPoint.Y,
                endPoint.X,
                endPoint.Y);
            PerformTouchAction(
                touchAction => touchAction
                    .Press(startPoint.X, startPoint.Y)
                    .Wait(AqualityServices.Get<ITouchActionsSettings>().SwipeDuration),
                endPoint);
        }

        public void SwipeWithLongPress(Point startPoint, Point endPoint)
        {
            AqualityServices.LocalizedLogger.Info(
               "loc.action.swipeLongPress",
               startPoint.X,
               startPoint.Y,
               endPoint.X,
               endPoint.Y);
            PerformTouchAction(touchAction => touchAction.LongPress(startPoint.X, startPoint.Y), endPoint);
        }

        protected void PerformTouchAction(Func<ITouchAction, ITouchAction> function, Point endPoint)
        {
            var actionRetrier = AqualityServices.Get<IElementActionRetrier>();
            var touchAction = new TouchAction(AqualityServices.Application.Driver);
            actionRetrier.DoWithRetry(() =>
                function(touchAction).MoveTo(endPoint.X, endPoint.Y).Release().Perform());
        }
    }
}