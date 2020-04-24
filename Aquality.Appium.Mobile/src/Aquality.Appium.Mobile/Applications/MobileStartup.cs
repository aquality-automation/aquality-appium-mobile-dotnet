using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Configurations;
using CoreElementFactory = Aquality.Selenium.Core.Elements.Interfaces.IElementFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Logging;
using System.Reflection;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Elements;
using Aquality.Appium.Mobile.Configurations;
using Aquality.Appium.Mobile.Screens.ScreenFactory;

namespace Aquality.Appium.Mobile.Applications
{
    /// <summary>
    /// Provides functionality to  register services
    /// </summary>
    public class MobileStartup : Startup
    {
        public override IServiceCollection ConfigureServices(IServiceCollection services, Func<IServiceProvider, IApplication> applicationProvider,
            ISettingsFile settings = null)
        {
            settings = settings ?? GetSettings();
            base.ConfigureServices(services, applicationProvider, settings);
            services.AddTransient<IElementFactory, ElementFactory>();
            services.AddTransient<CoreElementFactory, ElementFactory>();
            services.AddSingleton<IApplicationProfile, ApplicationProfile>();            
            services.AddSingleton<ILocalServiceSettings, LocalServiceSettings>();            
            services.AddSingleton<ILocalizationManager>(serviceProvider => new LocalizationManager(serviceProvider.GetRequiredService<ILoggerConfiguration>(), serviceProvider.GetRequiredService<Logger>(), Assembly.GetExecutingAssembly()));
            services.AddSingleton<IScreenFactory>(serviceProvider => 
            {
                if (serviceProvider.GetRequiredService<IApplicationProfile>().PlatformName == PlatformName.Android)
                {
                    return new AndroidScreenFactory();
                }
                else
                {
                    return new IOSScreenFactory();
                }
            });
            services.AddTransient(serviceProvider => AqualityServices.ApplicationFactory);
            services.AddScoped(serviceProvider => applicationProvider(serviceProvider) as IMobileApplication);
            return services;
        }
    }
}
