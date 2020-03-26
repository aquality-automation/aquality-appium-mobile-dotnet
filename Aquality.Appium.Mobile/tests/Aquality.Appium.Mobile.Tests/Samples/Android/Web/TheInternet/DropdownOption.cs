namespace Aquality.Appium.Mobile.Tests.Samples.Android.Web.TheInternet
{
    public enum DropdownOption
    {
        Default = 0,
        First = 1,
        Second = 2
    }

    public static class DropdownOptionExtensions
    {
        public static int GetIndex(this DropdownOption dropdownOption) => (int)dropdownOption;

        public static string GetValue(this DropdownOption dropdownOption) =>
            dropdownOption == DropdownOption.Default
                ? string.Empty
                : GetIndex(dropdownOption).ToString();
        public static string GetText(this DropdownOption dropdownOption) =>
            dropdownOption == DropdownOption.Default
                ? "Please select an option"
                : $"Option {GetIndex(dropdownOption)}";
    }
}
