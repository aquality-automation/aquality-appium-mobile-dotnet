using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Elements
{
    public class Link : Element, ILink
    {
        protected internal Link(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        public string Href => GetAttribute(Attributes.Href);

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.link");
    }
}
