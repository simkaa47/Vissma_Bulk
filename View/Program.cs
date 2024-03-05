using Avalonia;
using Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using View.ViewModels;

namespace View
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            var provider = BuildServiceProvider();
            var _logger = provider.GetService<ILogger<Program>>();
            InnerMain(provider, _logger, args);
        }

        private static IServiceProvider BuildServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplicationServices();
            services.AddSingleton<EventViewModel>();
            services.AddLogging(logging =>
            {
#if DEBUG
                logging.AddDebug();
#endif
            });
            var prov = services.BuildServiceProvider();
            return prov;
        }


        // Avalonia configuration, don't remove; also used by visual designer.
        // Can't be made private without breaking the designer
        // ReSharper disable once MemberCanBePrivate.Global
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
        }

        private static AppBuilder BuildAvaloniaAppWithServices(IServiceProvider serviceProvider)
        {
            return AppBuilder.Configure(() => new App(serviceProvider))
                .UsePlatformDetect()
                .LogToTrace();
        }

        private static void InnerMain(IServiceProvider serviceProvider, ILogger logger, string[] args)
        {
            logger.LogInformation("Start Vissma Lab");

            // We can't use StartWithClassicDesktopLifetime as we need control over the lifetime
            var avaloniaBuilder = BuildAvaloniaAppWithServices(serviceProvider);
            avaloniaBuilder.StartWithClassicDesktopLifetime(args);


            // This loop is here so that we can restart the avalonia GUI to show Thrive run errors and provide crash
            // reporting

        }
    }
}