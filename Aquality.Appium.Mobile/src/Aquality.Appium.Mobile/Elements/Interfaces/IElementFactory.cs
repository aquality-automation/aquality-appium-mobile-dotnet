using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;
using CoreElementFactory = Aquality.Selenium.Core.Elements.Interfaces.IElementFactory;

namespace Aquality.Appium.Mobile.Elements.Interfaces
{
    public interface IElementFactory : CoreElementFactory
    {
        /// <summary>
        /// Creates element according to passed parameters.
        /// </summary>
        /// <typeparam name="T">Type of the element to be obtained.</typeparam>
        /// <param name="locator">Locator of the target element.</param>
        /// <param name="name">Name of the target element.</param>
        /// <param name="state">Visibility state of the target element.</param>
        /// <returns></returns>
        T Get<T>(By locator, string name, ElementState state = ElementState.Displayed) where T : IElement;

        /// <summary>
        /// Creates element that implements IButton interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements IButton interface.</returns>
        IButton GetButton(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements ICheckBox interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements ICheckBox interface.</returns>
        ICheckBox GetCheckBox(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements IComboBox interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements IComboBox interface.</returns>
        IComboBox GetComboBox(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements ILabel interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements ILabel interface.</returns>
        ILabel GetLabel(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements ILink interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements ILink interface.</returns>
        ILink GetLink(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements IRadioButton interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements IRadioButton interface.</returns>
        IRadioButton GetRadioButton(By locator, string name, ElementState state = ElementState.Displayed);

        /// <summary>
        /// Creates element that implements ITextBox interface.
        /// </summary>
        /// <param name="locator">Element locator.</param>
        /// <param name="name">Element name.</param>
        /// <param name="state">Element state.</param>
        /// <returns> Instance of element that implements ITextBox interface.</returns>
        ITextBox GetTextBox(By locator, string name, ElementState state = ElementState.Displayed);
    }
}
