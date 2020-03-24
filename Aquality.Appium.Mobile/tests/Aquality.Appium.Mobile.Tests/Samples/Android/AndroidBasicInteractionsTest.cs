﻿using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Tests.Samples.Android.ApiDemosScreens;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    public class AndroidBasicInteractionsTest
    {
        [TearDown]
        public void TearDown()
        {
            if (AqualityServices.IsApplicationStarted)
            {
                AqualityServices.Application.Quit();
            }            
        }

        [Test]
        public void SendKeys()
        {
            new MainMenuScreen().StartSearch();
            var searchScreen = new InvokeSearchScreen();
            Assume.That(searchScreen.IsDisplayed, $"{searchScreen.Name} should be opened from the menu");
            const string query = "Hello world!";
            searchScreen.SubmitSearch(query);
            Assert.AreEqual(query, searchScreen.SearchResult, "Search result don't match to entered query");
        }

        [Test]
        public void AlertInteraction()
        {
            LogStep("Open the 'Alert Dialog' activity of the android app");
            new MainMenuScreen().OpenAlerts();

            LogStep("Click button that opens a dialog");
            new AlertsMenuScreen().OpenTwoButtonsDialog();

            LogStep("Check that the dialog is there");
            var alertDialog = new TwoButtonsAlert();
            const string expectedText = "Lorem ipsum dolor sit aie consectetur adipiscingPlloaso mako nuto siwuf cakso dodtos anr koop.";
            Assert.AreEqual(expectedText,
                alertDialog.AlertText.Replace("\r", string.Empty).Replace("\n", string.Empty), "Alert text should match to expected");

            LogStep("Close the dialog");
            alertDialog.Close();
        }

        private void LogStep(string step)
        {
            AqualityServices.Logger.Info(step);
        }
    }
}
