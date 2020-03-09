using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface IComboBox : IElement
    {
        /// <summary>
        /// Select by index.
        /// </summary>
        /// <param name="index">Number of selected option.</param>
        void SelectByIndex(int index);

        /// <summary>
        /// Select by visible text.
        /// </summary>
        /// <param name="text">Text to be selected.</param>
        void SelectByText(string text);

        /// <summary>
        /// Open Dropdown and select by visible text.
        /// </summary>
        /// <param name="value">Text to be selected.</param>
        void ClickAndSelectByText(string value);

        /// <summary>
        /// Select by containing visible text.
        /// </summary>
        /// <param name="text">Visible text.</param>
        void SelectByContainingText(string text);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void SelectByContainingValue(string value);

        /// <summary>
        /// Select by value.
        /// </summary>
        /// <param name="value">Argument value.</param>
        void SelectByValue(string value);

        /// <summary>
        /// Open Dropdown and select by value.
        /// </summary>
        /// <param name="value">Argument value.</param>
        void ClickAndSelectByValue(string value);

        /// <summary>
        /// Gets text of selected option.
        /// </summary>
        string SelectedText { get; }

        /// <summary>
        /// Gets value of selected option.
        /// </summary>
        string SelectedValue { get; }

        /// <summary>
        /// Gets options' texts list.
        /// </summary>
        IList<string> Texts { get; }

        /// <summary>
        /// Gets values list.
        /// </summary>
        IList<string> Values { get; }
    }
}
