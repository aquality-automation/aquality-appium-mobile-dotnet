namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface ICheckBox : IElement
    {
        /// <summary>
        /// Set true.
        /// </summary>
        void Check();

        /// <summary>
        /// Get the value of the checkbox: true if is checked, false otherwise.
        /// </summary>
        bool IsChecked { get; }

        /// <summary>
        /// Reverse state.
        /// </summary>
        void Toggle();

        /// <summary>
        /// Set the checkbox to false.
        /// </summary>
        void Uncheck();
    }
}
