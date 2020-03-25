using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    public abstract class BaseCheckBoxTest
    {
        protected abstract void OpenCheckBoxesScreen();

        protected abstract ICheckBox GetCheckBox(int number);

        public void TestCheckBox()
        {
            OpenCheckBoxesScreen();
            var checkBox1 = GetCheckBox(1);
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked initially");
            checkBox1.Click();
            Assert.IsTrue(checkBox1.IsChecked, "Checkbox should be checked after first click on it");
            checkBox1.Uncheck();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after uncheck");
            checkBox1.Toggle();
            Assert.IsTrue(checkBox1.IsChecked, "Checkbox should be checked after toggle from unchecked state");
            checkBox1.Toggle();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after toggle from checked state");
            GetCheckBox(2).Check();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after checking other checkbox");
        }
    }
}
