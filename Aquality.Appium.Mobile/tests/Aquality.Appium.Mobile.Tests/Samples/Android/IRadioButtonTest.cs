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
            IRadioButton button2 = radioButtonTest.GetRadioButton(2);
            Assert.That(button2.IsChecked, Is.False, "RadioButton should not be checked initially");
            button2.Click();
            Assert.That(button2.IsChecked, Is.True, "RadioButton should be checked after click on it");
            radioButtonTest.GetRadioButton(1).Click();
            Assert.That(button2.IsChecked, Is.False,
                    $"RadioButton {button2.Name} should not be checked after click on another option");
        }
    }
}
