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
            Assert.That(checkBox1.IsChecked, Is.False, "Checkbox should not be checked initially");
            checkBox1.Click();
            Assert.That(checkBox1.IsChecked, Is.True, "Checkbox should be checked after first click on it");
            checkBox1.Uncheck();
            Assert.That(checkBox1.IsChecked, Is.False, "Checkbox should not be checked after uncheck");
            checkBox1.Toggle();
            Assert.That(checkBox1.IsChecked, Is.True, "Checkbox should be checked after toggle from unchecked state");
            checkBox1.Toggle();
            Assert.That(checkBox1.IsChecked, Is.False, "Checkbox should not be checked after toggle from checked state");
            checkBoxTest.GetCheckBox(2).Check();
            Assert.That(checkBox1.IsChecked, Is.False, "Checkbox should not be checked after checking other checkbox");
        }
    }
}
