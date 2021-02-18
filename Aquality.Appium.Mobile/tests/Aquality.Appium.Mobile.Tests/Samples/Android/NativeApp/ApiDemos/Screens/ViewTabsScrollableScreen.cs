using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.NativeApp.ApiDemos.Screens
{
    public class ViewTabsScrollableScreen : ApplicationActivityScreen
    {
        public ViewTabsScrollableScreen() : base(By.Id("android:id/content"), "View/Tabs/Scrollable")
        {
        }

        protected override string Activity => ".view.Tabs5";

        public IButton GetTab(int tabNumber) =>
            ElementFactory.GetButton(
                By.XPath($"//*[@text='TAB {tabNumber}' and @resource-id = 'android:id/title']"),
                tabNumber.ToString());

        public ILabel GetTabContent(int tabNumber) =>
            ElementFactory.GetLabel(
                By.XPath($"//*[@text='{GenerateTabText(tabNumber)}']"),
                tabNumber.ToString());

        public void SwipeTab(int startTabNumber, int endTabNumber)
        {
            var endTabPoint = GetTab(endTabNumber).GetElement().Location;
            GetTab(startTabNumber).TouchActions.Swipe(endTabPoint);
        }

        public string GetTabContentText(int tabNumber) => GetTabContent(tabNumber).GetElement().Text;

        public void SelectTab(int tabNumber) => GetTab(tabNumber).Click();

        private string GenerateTabText(int tabNumber) => $"Content for tab with tag Tab {tabNumber}";
    }
}
