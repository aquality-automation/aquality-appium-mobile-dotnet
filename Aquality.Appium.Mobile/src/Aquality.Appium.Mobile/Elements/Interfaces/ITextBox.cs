namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface ITextBox : IElement
    {
        /// <summary>
        /// Enter the text in the box.
        /// </summary>
        /// <param name="value">Text.</param>
        void Type(string value);

        /// <summary>
        /// Enter the text in the box, inputted value isn't logged.
        /// </summary>
        /// <param name="value">Text.</param>
        void TypeSecret(string value);

        /// <summary>
        /// Clears input.
        /// </summary>
        void Clear();

        /// <summary>
        /// Clears input and enters text in the box.
        /// </summary>
        /// <param name="value">Text.</param>
        void ClearAndType(string value);

        /// <summary>
        /// Clears input and enters text in the box, inputted value isn't logged.
        /// </summary>
        /// <param name="value">Text.</param>
        void ClearAndTypeSecret(string value);

        /// <summary>
        /// Gets value of field.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Focuses on the element using send keys.
        /// </summary>
        void Focus();

        /// <summary>
        /// Removes focus from the element using send keys.
        /// </summary>
        void Unfocus();
    }
}
