﻿using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Applications
{
    public abstract class ApplicationFactory : IApplicationFactory
    {
        public abstract IMobileApplication Application { get; }

        protected virtual AppiumDriver<AppiumWebElement> GetDriver(Uri serviceUrl)
        {
            var platformName = AqualityServices.ApplicationProfile.PlatformName;
            var driverOptions = AqualityServices.ApplicationProfile.DriverSettings.AppiumOptions;
            var commandTimeout = AqualityServices.Get<ITimeoutConfiguration>().Command;
            return new CustomActionRetrier().DoWithRetry(
                () => CreateSession(platformName, serviceUrl, driverOptions, commandTimeout));
        }

        protected virtual AppiumDriver<AppiumWebElement> CreateSession(PlatformName platformName, Uri serviceUrl, AppiumOptions driverOptions, TimeSpan commandTimeout)
        {
            AqualityServices.LocalizedLogger.Info("loc.application.driver.remote", serviceUrl);
            AppiumDriver<AppiumWebElement> driver;
            switch (platformName)
            {
                case PlatformName.Android:
                    driver = new AndroidDriver<AppiumWebElement>(serviceUrl, driverOptions, commandTimeout);
                    break;
                case PlatformName.IOS:
                    driver = new IOSDriver<AppiumWebElement>(serviceUrl, driverOptions, commandTimeout);
                    break;
                default:
                    throw GetLoggedWrongPlatformNameException(platformName.ToString());
            }

            return driver;
        }

        protected class CustomActionRetrier : ActionRetrier
        {
            private static readonly string[] handledErrorMessages = new string[]
            {
                "timed out",
                "session not created",
                "appium settings app is not running",
                "socket hang up",
                "stream was destroyed",
                "invalid or unrecognized response"
            };

            public CustomActionRetrier() 
                : base(AqualityServices.Get<IRetryConfiguration>())
            {
            }

            protected override bool IsExceptionHandled(IEnumerable<Type> handledExceptions, Exception exception)
            {
                var exceptions = new List<Type>(handledExceptions ?? new List<Type>())
                {
                    typeof(WebDriverException)
                };
                return base.IsExceptionHandled(exceptions, exception) 
                    && handledErrorMessages.Any(message => exception.Message.ToLower().Contains(message));
            }
        }

        protected PlatformNotSupportedException GetLoggedWrongPlatformNameException(string actualPlatform)
        {
            var message = AqualityServices.Get<ILocalizationManager>()
                .GetLocalizedMessage("loc.platform.name.wrong", actualPlatform);
            var exception = new PlatformNotSupportedException(message);
            AqualityServices.Logger.Fatal(message, exception);
            return exception;
        }

        protected void LogApplicationIsReady()
        {
            AqualityServices.LocalizedLogger.Info("loc.application.ready", AqualityServices.ApplicationProfile.PlatformName);
        }
    }
}
