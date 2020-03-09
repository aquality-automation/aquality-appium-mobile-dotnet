namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface IRadioButton : IElement
    {
        /// <summary>
        /// Gets RadioButton state: true if is checked, false otherwise.
        /// </summary>
        bool IsChecked { get; }
    }
}
