using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp
{
    public class AndroidBasicInteractionsTest : UITest, ICheckBoxTest, IRadioButtonTest
    {
        [OneTimeTearDown]
        public void TearDown()
        {
            QuitApp();
        }

        [Test]
        public void SendKeys()
        {
            var searchScreen = new InvokeSearchScreen();
            searchScreen.Open();
            Assume.That(searchScreen.State.IsDisplayed, $"{searchScreen.Name} should be opened from the menu");
            const string query = "Hello world!";
            searchScreen.SubmitSearch(query);
            Assert.AreEqual(query, searchScreen.SearchResult, "Search result don't match to entered query");
        }

        [Test]
        public void SaveAndCompareScreenDump()
        {
            var searchScreen = new InvokeSearchScreen();
            searchScreen.Open();
            Assume.That(searchScreen.State.IsDisplayed, $"{searchScreen.Name} should be opened from the menu");

            searchScreen.Dump.Save();
            Assert.That(searchScreen.Dump.Compare(), Is.EqualTo(0), "Current screen should have no visual difference comparing to just saved dump");
            const string query = "Hello world!";
            searchScreen.TypeQuery(query);
            Assert.That(searchScreen.Dump.Compare(), Is.GreaterThan(0), "Current screen should have visual difference comparing to dump saved before the search");
        }

        [Test]
        public void AlertInteraction()
        {
            LogStep("Open the 'Alert Dialog' activity of the android app");
            var alertsMenu = new AlertsMenuScreen();
            alertsMenu.Open();

            LogStep("Click button that opens a dialog");
            alertsMenu.OpenTwoButtonsDialog();

            LogStep("Check that the dialog is there");
            var alertDialog = new TwoButtonsAlert();
            const string expectedText = "Lorem ipsum dolor sit aie consectetur adipiscingPlloaso mako nuto siwuf cakso dodtos anr koop.";
            Assert.AreEqual(expectedText,
                alertDialog.AlertText.Replace("\r", string.Empty).Replace("\n", string.Empty), "Alert text should match to expected");

            LogStep("Close the dialog");
            alertDialog.Close();
        }

        [Test]
        public void TestVerticalSwipeToElement()
        {
            var viewControlsScreen = new ViewControlsScreen();
            OpenRadioButtonsScreen();
            viewControlsScreen.ScrollToAllInsideScrollViewLabel();
            Assert.AreEqual(
                viewControlsScreen.AllInsideScrollViewLabelText,
                "(And all inside of a ScrollView!)",
                "Label text does not match expected");
            viewControlsScreen.ScrollToDisabledButton();
            Assert.IsFalse(viewControlsScreen.IsDisabledButtonClickable);
        }

        [Test]
        public void TestHorizontalSwipeToElement()
        {
            var tabTextDoesNotMatchFriendlyMessage = "Tab text does not match expected";
            var tabContentFriendlyMessage = "Content for tab with tag Tab";
            var tabSevenTag = 7;
            var tabFourTag = 4;
            var viewTabsScrollableScreen = new ViewTabsScrollableScreen();
            OpenViewTabsScrollableScreen();
            Assert.IsTrue(viewTabsScrollableScreen.State.IsDisplayed);
            viewTabsScrollableScreen.SwipeTab(tabFourTag, 1);
            viewTabsScrollableScreen.SelectTab(tabSevenTag);
            Assert.AreEqual(
                viewTabsScrollableScreen.GetTabContentText(tabSevenTag),
                $"{tabContentFriendlyMessage} {tabSevenTag}",
                tabTextDoesNotMatchFriendlyMessage);
            viewTabsScrollableScreen.SwipeTab(5, tabSevenTag);
            viewTabsScrollableScreen.SelectTab(tabFourTag);
            Assert.AreEqual(
                viewTabsScrollableScreen.GetTabContentText(tabFourTag),
                $"{tabContentFriendlyMessage} {tabFourTag}",
                tabTextDoesNotMatchFriendlyMessage);
        }

        [Test]
        public void TestCheckBox() => this.InvokeCheckBoxTest();

        [Test]
        public void TestRadioButton() => this.InvokeRadioButtonTest();

        private void LogStep(string step)
        {
            AqualityServices.Logger.Info(step);
        }

        public void OpenRadioButtonsScreen() => new ViewControlsScreen().Open();

        public IRadioButton GetRadioButton(int number) => new ViewControlsScreen().GetRadioButton(number);

        public void OpenCheckBoxesScreen() => new ViewControlsScreen().Open();

        public ICheckBox GetCheckBox(int number) => new ViewControlsScreen().GetCheckBox(number);

        public void OpenViewTabsScrollableScreen() => new ViewTabsScrollableScreen().Open();
    }
}
