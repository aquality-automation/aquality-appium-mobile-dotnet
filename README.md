# Aquality Appium Mobile for .NET

[![Build Status](https://dev.azure.com/aquality-automation/aquality-automation/_apis/build/status/aquality-automation.aquality-appium-mobile-dotnet?branchName=master)](https://dev.azure.com/aquality-automation/aquality-automation/_build/latest?definitionId=7&branchName=master)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=aquality-automation_aquality-appium-mobile-dotnet&metric=alert_status)](https://sonarcloud.io/dashboard?id=aquality-automation_aquality-appium-mobile-dotnet)
[![NuGet](https://img.shields.io/nuget/v/Aquality.Appium.Mobile)](https://www.nuget.org/packages/Aquality.Appium.Mobile)

### Overview

This package is a library designed to simplify automation of Android and iOS mobile applications using Appium.

You've got to use this set of methods, related to most common actions performed with web elements.

Most of performed methods are logged using NLog, so you can easily see a history of performed actions in your log.

We use interfaces where is possible, so you can implement your own version of target interface with no need to rewrite other classes. 

### Quick start

To start the project using Aquality.Appium.Mobile framework, you can [download our template BDD project by this link.](https://github.com/aquality-automation/aquality-appium-mobile-dotnet-template)

Alternatively, you can follow the steps below:


1. Add the nuget dependency Aquality.Appium.Mobile to your project.

2. Configure path to your application at settings.json:
 - Create a `Resources` folder in your project and copy [settings.json](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Resources/settings.json) into it. 
 - Select `Copy to Output Directory`: `Copy always` option at settings.json file properties.
 - Open settings.json and find `applicationPath` option under the `driverSettings` section of desired platform. Replace the value with full or relative path to your app, e.g. `./Resources/Apps/ApiDemos-debug.apk`.

3. Ensure that [Appium server](https://appium.io) is set up at your machine where the code would be executed, and the address/port match to set in your `settings.json` in `remoteConnectionUrl` parameter.
If the parameter `isRemote` in your settings.json is set to `false`, this means that AppiumDriverLocalService would be used to setup Appium server using Node.js. This option requires specific version of node.js to be preinstalled on your machine (Please read more [here](http://appium.io/docs/en/contributing-to-appium/appium-from-source/#nodejs) )

> Note:
After migration to Appium v.5, we started using Appium server v.2 in our [azure-pipelines](azure-pipelines.yml). 
> It has some breaking changes, described [here](https://appium.github.io/appium/docs/en/2.0/guides/migrating-1-to-2/).
> In particular:
> 1. Please install required driver manually:
> ```yaml
> npm install -g appium@next
> appium driver install uiautomator2
> 2. As soon as we continue to use "remoteConnectionUrl": "http://127.0.0.1:4723/wd/hub" in our [settings.json](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Resources/settings.json), we need to specify the `--base-path` when starting Appium server:
> ```yaml
> appium --allow-insecure chromedriver_autodownload --base-path /wd/hub &
> ```
> 3. We also recommend disabling element caching and w3c in chromeOptions when you run Android Chrome session. Take a look at example here: [settings.androidwebsession.json](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Resources/settings.androidwebsession.json).

4. (optional) Launch an application directly by calling `var application = AqualityServices.Application;`. 
> Note: 
If you don't start an Application directly, it would be started with the first call of any Aquality service or class requiring interacting with the Application.

5. That's it! Now you are able work with Application via AqualityServices or via element services.
Please take a look at our example tests [here](Aquality.Appium.Mobile/tests/Aquality.Appium.Mobile.Tests/Samples/)

6. To interact with Application's forms and elements, we recommend following the Page/Screen Objects pattern. This approach is fully integrated into our package.
To start with that, you will need to create a separate class for each window/form of your application, and inherit this class from the [Screen](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Screens/Screen.cs). 

> We recommend to use separate Screen class for each form of your application. You can take advantage of inheritance and composition pattern. We also suggest not to mix app different platforms in single class: take advantage of interfaces instead, adding the default implementation to them if is needed.

7. From the Screen Object perspective, each Screen consists of elements on it (e.g. Buttons, TextBox, Labels and so on). 
To interact with elements, on your form class create fields of type IButton, ITextBox, ILabel, and initialize them using the `AqualityServices.ElementFactory`. Created elements have a various methods to interact with them. We recommend combining actions into a business-level methods:

```csharp
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Tests.Samples.Android.ApiDemosScreens
{
    public class InvokeSearchScreen : AndroidScreen
    {

        private readonly ITextBox searchTextBox;
        private readonly IButton startSearchButton;
        private readonly ILabel searchResultLabel;

        public InvokeSearchScreen() : base(By.XPath("//android.widget.TextView[@text='App/Search/Invoke Search']"), "Invoke Search")
        {
            searchTextBox = ElementFactory.GetTextBox(By.Id("txt_query_prefill"), "Search");
            startSearchButton = ElementFactory.GetButton(By.Id("btn_start_search"), "Start search");
            searchResultLabel = ElementFactory.GetLabel(By.Id("android:id/search_src_text"), "Search results");
        }

        public void SubmitSearch(string query)
        {
            searchTextBox.ClearAndType(query);
            startSearchButton.Click();
        }

        public string SearchResult => searchResultLabel.Text;
    }
}
```

8. We use `Microsoft.Extensions.DependencyInjection` inside the `AqualityServices` to inject dependencies, so you can simply implement your MobileStartup extended from [MobileStartup](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Applications/MobileStartup.cs) and inject it to `AqualityServices.SetStartup(yourStartup)`.

### ScreenFactory

When you automate tests for both iOS and Android platforms it is good to have only one set of tests and different implementations of screens. `ScreenFactory` allows to do this. You can define abstract classes for your screens and have different implementations for iOS and Android platforms. After that you can use `ScreenFactory` to resolve a necessary screen depending on the chosen platform.

1. Set `screensLocation` property in `settings.json`. It is a name of Assembly where you define screens.

2. Define abstract classes for the screens:

```csharp
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Template.Screens.Login
{
    public abstract class LoginScreen : Screen
    {
        private readonly ITextBox usernameTxb;
        private readonly ITextBox passwordTxb;
        private readonly IButton loginBtn;

        protected LoginScreen(By locator) : base(locator, "Login")
        {
            usernameTxb = ElementFactory.GetTextBox(UsernameTxbLoc, "Username");
            passwordTxb = ElementFactory.GetTextBox(PasswordTxbLoc, "Password");
            loginBtn = ElementFactory.GetButton(LoginBtnLoc, "Login");
        }

        protected abstract By UsernameTxbLoc { get; }

        protected abstract By PasswordTxbLoc { get; }

        protected abstract By LoginBtnLoc { get; }

        public LoginScreen SetUsername(string username)
        {
            usernameTxb.SendKeys(username);
            return this;
        }

        public LoginScreen SetPassword(string password)
        {
            passwordTxb.TypeSecret(password);
            return this;
        }

        public void TapLogin() => loginBtn.Click();
    }
}
```

3. Implement interface (Android example):

```csharp
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Screens.ScreenFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Template.Screens.Login
{
    [ScreenType(PlatformName.Android)]
    public sealed class AndroidLoginScreen : LoginScreen
    {
        public AndroidLoginScreen() : base(By.XPath("//android.widget.TextView[@text='Login']"))
        {
        }

        protected override By UsernameTxbLoc => MobileBy.AccessibilityId("username");

        protected override By PasswordTxbLoc => MobileBy.AccessibilityId("password");

        protected override By LoginBtnLoc => MobileBy.AccessibilityId("loginBtn");
    }
}
```

4. Resolve screen in test:

```csharp
var loginScreen = AqualityServices.ScreenFactory.GetScreen<LoginScreen>();
```

### Devices

Our library allows you to run tests on different devices and store their settings (like udid, name, etc.) in JSON files.

You have to add [devices.json](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Resources/devices.json) file to resources where you can define a set of devices which you use to run tests.

It is possible to set default device for each platform in [settings.json](Aquality.Appium.Mobile/src/Aquality.Appium.Mobile/Resources/settings.json) by defining `deviceKey` property which is a key of device settings from `devices.json` file.

You can also create several profiles with devices by adding files with suffixes `devices.<devicesProfile>.json` (like `devices.set1.json`) and then specify profile using environment variable `devicesProfile: set1`.

### License
Library's source code is made available under the [Apache 2.0 license](LICENSE).
