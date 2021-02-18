﻿using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Configurations;
using Aquality.Selenium.Core.Elements.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Aquality.Appium.Mobile.Elements.Actions
{
    public class ElementTouchActions : IElementTouchActions
    {
        private readonly IElement element;
        private readonly ITouchActionsSettings touchActionsSettings = AqualityServices.Get<ITouchActionsSettings>();
        private readonly Point scrollDownStartPoint;
        private readonly Point scrollDownEndPoint;
        private readonly Point swipeLeftStartPoint;
        private readonly Point swipeLeftEndPoint;
        private readonly Point scrollUpStartPoint;
        private readonly Point scrollUpEndPoint;
        private readonly Point swipeRightStartPoint;
        private readonly Point swipeRightEndPoint;

        public ElementTouchActions(IElement element)
        {
            this.element = element;
            var horizontalOffset = touchActionsSettings.SwipeHorizontalOffset;
            var verticalOffset = touchActionsSettings.SwipeVerticalOffset;
            scrollDownStartPoint = RecalculatePointCoordinates(
                GetBottomRightCornerPoint(),
                1 - horizontalOffset,
                1 - verticalOffset);
            scrollDownEndPoint = RecalculatePointCoordinates(
                GetBottomRightCornerPoint(),
                horizontalOffset,
                verticalOffset);
            swipeLeftStartPoint = RecalculatePointCoordinates(
                GetBottomRightCornerPoint(),
                1 - verticalOffset,
                1 - horizontalOffset);
            swipeLeftEndPoint = RecalculatePointCoordinates(
                GetBottomRightCornerPoint(),
                horizontalOffset,
                verticalOffset);
            scrollUpStartPoint = scrollDownEndPoint;
            scrollUpEndPoint = scrollDownStartPoint;
            swipeRightStartPoint = swipeLeftEndPoint;
            swipeRightEndPoint = swipeLeftStartPoint;
        }

        public void Swipe(Point endPoint)
        {
            AqualityServices.TouchActions.Swipe(GetElementLocation(), endPoint);
        }

        public void SwipeWithLongPress(Point endPoint)
        {
            AqualityServices.TouchActions.SwipeWithLongPress(GetElementLocation(), endPoint);
        }

        public void ScrollToElement(SwipeDirection direction)
        {
            var numberOfRetries = touchActionsSettings.SwipeRetries;
            var touchActions = AqualityServices.TouchActions;
            while (numberOfRetries-- > 0 && !element.State.IsDisplayed)
            {
                switch (direction)
                {
                    case SwipeDirection.Down:
                        touchActions.Swipe(scrollDownStartPoint, scrollDownEndPoint);
                        break;
                    case SwipeDirection.Up:
                        touchActions.Swipe(scrollUpStartPoint, scrollUpEndPoint);
                        break;
                    case SwipeDirection.Left:
                        touchActions.Swipe(swipeLeftStartPoint, swipeLeftEndPoint);
                        break;
                    case SwipeDirection.Right:
                        touchActions.Swipe(swipeRightStartPoint, swipeRightEndPoint);
                        break;
                    default:
                        throw new InvalidEnumArgumentException($"'{direction}' direction does not exist");
                }
            }
        }

        private Point GetElementLocation() => element.GetElement().Location;

        private Point RecalculatePointCoordinates(
            Point point,
            double horizontalOffset,
            double verticalOffset)
        {
            return new Point((int)(point.X * horizontalOffset),
                             (int)(point.Y * verticalOffset));
        }

        private Point GetBottomRightCornerPoint()
        {
            var screnSize = AqualityServices.Application.Driver.Manage().Window.Size;
            return new Point(screnSize.Width, screnSize.Height);
        }
    }
}
