using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Waitings;
using CoreFactory = Aquality.Selenium.Core.Elements.ElementFactory;
using IElementFactory = Aquality.Appium.Mobile.Elements.Interfaces.IElementFactory;
using System;
using System.Collections.Generic;

namespace Aquality.Appium.Mobile.Elements
{
    public class ElementFactory : CoreFactory, IElementFactory
    {
        public ElementFactory(IConditionalWait conditionalWait, IElementFinder elementFinder, ILocalizationManager localizationManager)
            : base(conditionalWait, elementFinder, localizationManager)
        {
        }

        //TODO implement element getters

        protected override IDictionary<Type, Type> ElementTypesMap
        {
            get
            {
                return new Dictionary<Type, Type>
                {
                    /* TODO implement elements
                    { typeof(IButton), typeof(Button) },
                    { typeof(ICheckBox), typeof(CheckBox) },
                    { typeof(IComboBox), typeof(ComboBox) },
                    { typeof(ILabel), typeof(Label) },
                    { typeof(ILink), typeof(Link) },
                    { typeof(ITextBox), typeof(TextBox) },
                    { typeof(IRadioButton), typeof(RadioButton) }
                    */
                };
            }
        }
    }
}
