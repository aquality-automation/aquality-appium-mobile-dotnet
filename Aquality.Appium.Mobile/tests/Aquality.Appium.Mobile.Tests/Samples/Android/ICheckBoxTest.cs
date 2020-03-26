using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    public interface ICheckBoxTest
    {
        void OpenCheckBoxesScreen();

        ICheckBox GetCheckBox(int number);
    }

    public static class CheckBoxTestExtension 
    { 
        public static void InvokeCheckBoxTest(this ICheckBoxTest checkBoxTest)
        {
            checkBoxTest.OpenCheckBoxesScreen();
            var checkBox1 = checkBoxTest.GetCheckBox(1);
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked initially");
            checkBox1.Click();
            Assert.IsTrue(checkBox1.IsChecked, "Checkbox should be checked after first click on it");
            checkBox1.Uncheck();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after uncheck");
            checkBox1.Toggle();
            Assert.IsTrue(checkBox1.IsChecked, "Checkbox should be checked after toggle from unchecked state");
            checkBox1.Toggle();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after toggle from checked state");
            checkBoxTest.GetCheckBox(2).Check();
            Assert.IsFalse(checkBox1.IsChecked, "Checkbox should not be checked after checking other checkbox");
        }
    }
}
