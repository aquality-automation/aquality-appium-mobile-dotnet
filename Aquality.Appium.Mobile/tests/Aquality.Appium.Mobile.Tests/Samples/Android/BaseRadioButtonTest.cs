using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    public abstract class BaseRadioButtonTest
    {
        protected abstract void OpenRadioButtonsScreen();

        protected abstract IRadioButton GetRadioButton(int number);

        public void TestCheckBox()
        {
            OpenRadioButtonsScreen();
            IRadioButton button1 = GetRadioButton(1);
            Assert.IsFalse(button1.IsChecked, "RadioButton should not be checked initially");
            button1.Click();
            Assert.IsTrue(button1.IsChecked, "RadioButton should be checked after click on it");
            GetRadioButton(2).Click();
            Assert.IsFalse(button1.IsChecked,
                    $"RadioButton {button1.Name} should not be checked after click on another option");
        }
    }
}
