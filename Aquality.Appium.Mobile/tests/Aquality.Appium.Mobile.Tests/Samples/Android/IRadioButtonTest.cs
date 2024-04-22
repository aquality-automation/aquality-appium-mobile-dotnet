using Aquality.Appium.Mobile.Elements.Interfaces;
using NUnit.Framework;

namespace Aquality.Appium.Mobile.Tests.Samples.Android
{
    public interface IRadioButtonTest
    {
        void OpenRadioButtonsScreen();

        IRadioButton GetRadioButton(int number);
    }

    public static class RadioButtonTestExtension 
    { 
        public static void InvokeRadioButtonTest(this IRadioButtonTest radioButtonTest)
        {
            radioButtonTest.OpenRadioButtonsScreen();
            IRadioButton button1 = radioButtonTest.GetRadioButton(1);
            Assert.That(button1.IsChecked, Is.False, "RadioButton should not be checked initially");
            button1.Click();
            Assert.That(button1.IsChecked, Is.True, "RadioButton should be checked after click on it");
            radioButtonTest.GetRadioButton(2).Click();
            Assert.That(button1.IsChecked, Is.False,
                    $"RadioButton {button1.Name} should not be checked after click on another option");
        }
    }
}
