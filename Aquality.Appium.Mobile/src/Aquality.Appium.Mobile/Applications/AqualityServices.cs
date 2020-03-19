using Aquality.Appium.Mobile.Configurations;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Localization;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Core.Waitings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Aquality.Appium.Mobile.Applications
{
    /// <summary>
    /// Controls application and Aquality services
    /// </summary>
    public class AqualityServices : AqualityServices<IMobileApplication>
    {
        private static readonly ThreadLocal<MobileStartup> ApplicationStartupContainer = new ThreadLocal<MobileStartup>(() => new MobileStartup());
        private static readonly ThreadLocal<IApplicationFactory> ApplicationFactoryContainer = new ThreadLocal<IApplicationFactory>();

        /// <summary>
        /// Gets registered instance of localized logger
        /// </summary>
        public static IApplicationProfile ApplicationProfile => Get<IApplicationProfile>();

        /// <summary>
        /// Check if application already started.
        /// </summary>
        /// <value>true if application started and false otherwise.</value>
        public new static bool IsApplicationStarted => IsApplicationStarted();

        /// <summary>
        /// Gets registered instance of localized logger
        /// </summary>
        public static ILocalizedLogger LocalizedLogger => Get<ILocalizedLogger>();

        /// <summary>
        /// Gets registered instance of Appium local service settings.
        /// </summary>
        public static ILocalServiceSettings LocalServiceSettings => Get<ILocalServiceSettings>();

        /// <summary>
        /// Gets registered instance of Logger
        /// </summary>
        public static Logger Logger => Get<Logger>();

        /// <summary>
        /// Gets ConditionalWait object
        /// </summary>
        public static IConditionalWait ConditionalWait => Get<IConditionalWait>();

        /// <summary>
        /// Gets factory to create elements.
        /// </summary>
        public static IElementFactory ElementFactory => Get<IElementFactory>();

        /// <summary>
        /// Resolves required service from <see cref="ServiceProvider"/>
        /// </summary>
        /// <typeparam name="T">type of required service</typeparam>
        /// <exception cref="InvalidOperationException">Thrown if there is no service of the required type.</exception> 
        /// <returns></returns>
        public static T Get<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }

        /// <summary>
        /// Provides current instance of application
        /// </summary>
        public static IMobileApplication Application
        {
            get => GetApplication(StartApplicationFunction, ConfigureServices);
            set => SetApplication(value);
        }

        /// <summary>
        /// Method which allow user to override or add custom services.
        /// </summary>
        /// <param name="startup"><see cref="MobileStartup"/>> object with custom or overriden services.</param>
        public static void SetStartup(MobileStartup startup)
        {
            if (startup != null)
            {
                ApplicationStartupContainer.Value = startup;
                SetServiceProvider(ConfigureServices().BuildServiceProvider());
            }
            else
            {
                throw new ArgumentNullException(nameof(startup));
            }
        }

        /// <summary>
        /// Factory for application creation.
        /// </summary>
        public static IApplicationFactory ApplicationFactory
        {
            get
            {
                if (!ApplicationFactoryContainer.IsValueCreated)
                {
                    SetDefaultFactory();
                }
                return ApplicationFactoryContainer.Value;
            }
            set => ApplicationFactoryContainer.Value = value;
        }

        /// <summary>
        /// Sets default factory responsible for application creation.
        /// RemoteApplicationFactory if value set in configuration and LocalApplicationFactory otherwise.
        /// </summary>
        public static void SetDefaultFactory()
        {
            ApplicationFactory = ApplicationProfile.IsRemote ? new RemoteApplicationFactory() : (IApplicationFactory) new LocalApplicationFactory();
        }

        private static IServiceProvider ServiceProvider => GetServiceProvider(services => Application, ConfigureServices);

        private static Func<IServiceProvider, IMobileApplication> StartApplicationFunction
        {
            get
            {
                return (services) => ApplicationFactory.Application;
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            return ApplicationStartupContainer.Value.ConfigureServices(new ServiceCollection(), services => Application);
        }
    }
}
