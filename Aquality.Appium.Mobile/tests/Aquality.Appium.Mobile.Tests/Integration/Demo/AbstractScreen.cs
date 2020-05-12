using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aquality.Appium.Mobile.Tests.Integration.Demo
{
    public abstract class AbstractScreen : NewScreen
    {
        private readonly ITextBox usernameTxb;

        protected AbstractScreen(By locator, string name) : base(locator, name)
        {
            usernameTxb = ElementFactory.GetTextBox(UsernameTxbLoc, "");
        }

        protected abstract By UsernameTxbLoc { get; }

        public void Login(string username, string password)
        {
            usernameTxb.SendKeys(username);
        }
    }
}
