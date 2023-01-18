using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Aquality.Appium.Mobile.Actions
{
    public class TouchActions : ITouchActions
    {
        private TimeSpan SwipeDuration => AqualityServices.Get<ITouchActionsSettings>().SwipeDuration;

        private ActionSequence PressSequence(PointerInputDevice finger, Point startPoint) => new ActionSequence(finger, initialSize: 0)
            .AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startPoint.X, startPoint.Y, TimeSpan.Zero))
            .AddAction(finger.CreatePointerDown(MouseButton.Left));
            

        public void Swipe(Point startPoint, Point endPoint)
        {
            AqualityServices.LocalizedLogger.Info(
                "loc.action.swipe",
                startPoint.X,
                startPoint.Y,
                endPoint.X,
                endPoint.Y);
            PerformTouchAction(finger => PressSequence(finger, startPoint), endPoint);
        }

        public void SwipeWithLongPress(Point startPoint, Point endPoint)
        {
            AqualityServices.LocalizedLogger.Info(
               "loc.action.swipeLongPress",
               startPoint.X,
               startPoint.Y,
               endPoint.X,
               endPoint.Y);
            PerformTouchAction(finger => PressSequence(finger, startPoint).AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startPoint.X, startPoint.Y, SwipeDuration)), endPoint);
        }

        protected void PerformTouchAction(Func<PointerInputDevice, ActionSequence> getActionSequence, Point endPoint)
        {
            var actionRetrier = AqualityServices.Get<IElementActionRetrier>();
            var finger = new PointerInputDevice(PointerKind.Touch, "finger");
            var actionSequence = getActionSequence(finger)
                .AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endPoint.X, endPoint.Y, SwipeDuration))
                .AddAction(finger.CreatePointerUp(MouseButton.Left));

            actionRetrier.DoWithRetry(() =>
                AqualityServices.Application.Driver.PerformActions(new List<ActionSequence> { actionSequence }));
        }
    }
}
