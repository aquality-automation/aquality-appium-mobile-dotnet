using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Waitings;
using CoreFactory = Aquality.Selenium.Core.Elements.ElementFactory;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;
using System;
using System.Collections.Generic;
using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Core.Elements;
using IElement = Aquality.Appium.Mobile.Elements.Interfaces.IElement;

namespace Aquality.Appium.Mobile.Elements
{
    public class ElementFactory : CoreFactory, IElementFactory
    {
        public ElementFactory(IConditionalWait conditionalWait, IElementFinder elementFinder, ILocalizationManager localizationManager)
            : base(conditionalWait, elementFinder, localizationManager)
        {
        }

        protected override IDictionary<Type, Type> ElementTypesMap
        {
            get
            {
                return new Dictionary<Type, Type>
                {
                    { typeof(IButton), typeof(Button) },
                    { typeof(ICheckBox), typeof(CheckBox) },
                    { typeof(IComboBox), typeof(ComboBox) },
                    { typeof(ILabel), typeof(Label) },
                    { typeof(ILink), typeof(Link) },
                    { typeof(ITextBox), typeof(TextBox) },
                    { typeof(IRadioButton), typeof(RadioButton) }                    
                };
            }
        }

        public T Get<T>(By locator, string name, ElementState state = ElementState.Displayed) where T : IElement
        {
            return GetCustomElement(ResolveSupplier<T>(null), locator, name, state);
        }

        public ILink GetButton(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<ILink>(locator, name, state);
        }

        public ICheckBox GetCheckBox(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<ICheckBox>(locator, name, state);
        }

        public IComboBox GetComboBox(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<IComboBox>(locator, name, state);
        }

        public ILabel GetLabel(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<ILabel>(locator, name, state);
        }

        public ILink GetLink(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<ILink>(locator, name, state);
        }

        public IRadioButton GetRadioButton(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<IRadioButton>(locator, name, state);
        }

        public ITextBox GetTextBox(By locator, string name, ElementState state = ElementState.Displayed)
        {
            return Get<ITextBox>(locator, name, state);
        }
    }
}
