using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquality.Appium.Mobile.Configurations
{
    /// <summary>
    /// Class to support known capabilities that became properties of <see cref="AppiumOptions"/>.
    /// </summary>
    public abstract class CapabilityBasedSettings
    {
        protected virtual IDictionary<string, Action<AppiumOptions, object>> KnownCapabilitySetters => new Dictionary<string, Action<AppiumOptions, object>>();

        protected virtual void SetCapability(AppiumOptions options, KeyValuePair<string, object> capability)
        {
            try
            {
                options.AddAdditionalAppiumOption(capability.Key, capability.Value);
            }
            catch (ArgumentException exception)
            {
                if (exception.Message.StartsWith("There is already an option"))
                {
                    SetKnownProperty(options, capability, exception);
                }
                else
                {
                    throw;
                }
            }
        }

        private void SetKnownProperty(AppiumOptions options, KeyValuePair<string, object> capability, ArgumentException exception)
        {
            if (KnownCapabilitySetters.ContainsKey(capability.Key))
            {
                KnownCapabilitySetters[capability.Key](options, capability.Value);
            }
            else
            {
                SetOptionByPropertyName(options, capability, exception);
            }
        }

        private void SetOptionByPropertyName(AppiumOptions options, KeyValuePair<string, object> option, Exception exception)
        {
            var optionProperty = options
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(property => IsPropertyNameMatchOption(property.Name, option.Key) && property.CanWrite)
                            ?? throw exception;
            var propertyType = optionProperty.PropertyType;
            var valueToSet = IsEnumValue(propertyType, option.Value)
                ? ParseEnumValue(propertyType, option.Value)
                : option.Value;
            optionProperty.SetValue(options, valueToSet);
        }

        private bool IsPropertyNameMatchOption(string propertyName, string optionKey)
        {
            return propertyName.Equals(optionKey, StringComparison.InvariantCultureIgnoreCase)
                || optionKey.ToLowerInvariant().Contains(propertyName.ToLowerInvariant());
        }

        private object ParseEnumValue(Type propertyType, object optionValue)
        {
            return optionValue is string
                ? Enum.Parse(propertyType, optionValue.ToString(), ignoreCase: true)
                : Enum.ToObject(propertyType, Convert.ChangeType(optionValue, Enum.GetUnderlyingType(propertyType)));
        }

        private bool IsEnumValue(Type propertyType, object optionValue)
        {
            var valueAsString = optionValue.ToString();
            if (!propertyType.IsEnum || string.IsNullOrEmpty(valueAsString))
            {
                return false;
            }
            var normalizedValue = char.ToUpper(valueAsString[0]) +
                (valueAsString.Length > 1 ? valueAsString.Substring(1) : string.Empty);
            return propertyType.IsEnumDefined(normalizedValue)
                || propertyType.IsEnumDefined(valueAsString)
                || (IsValueOfIntegralNumericType(optionValue)
                    && propertyType.IsEnumDefined(Convert.ChangeType(optionValue, Enum.GetUnderlyingType(propertyType))));
        }

        private bool IsValueOfIntegralNumericType(object value)
        {
            return value is byte || value is sbyte
                || value is ushort || value is short
                || value is uint || value is int
                || value is ulong || value is long;
        }
    }
}
