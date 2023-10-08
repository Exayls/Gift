using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel;
using Gift.ApplicationService.services.Displayer;
using Gift.ApplicationService.services.SignalHandler.Bus;
using Gift.ApplicationService.services.Monitor.ConsoleMonitors;
using Gift.ApplicationService.services;
using Gift.ApplicationService.services.Renderer;
using Gift.ApplicationService.services.KeyInputHandler;
using Gift.ApplicationService.services.Monitor;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.services.SignalHandler.Ui;
using Gift.ApplicationService.services.SignalHandler.Key;

namespace Gift.src.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftTestServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration, DefaultConfiguration>();
            services.AddSingleton<IRenderer, Renderer>();
            services.AddSingleton<IDisplayService, DisplayService>();
            services.AddSingleton<IConsoleDisplayStringFormater, ConsoleDisplayStringFormater>();
            services.AddSingleton<IDisplayer, ConsoleDisplayer>();
            services.AddSingleton<IKeyInputHandler, KeyInputHandler>();
            services.AddSingleton<IKeyMapper, KeyMapper>();
            services.AddSingleton<IKeySignalHandler, KeySignalHandler>();
            services.AddSingleton<IConsoleSizeMonitor, ConsoleSizeMonitor>();
            services.AddSingleton<IMonitorManager, MonitorManager>();
            services.AddSingleton<ISignalBus, SignalBus>();
            services.AddSingleton<IGiftUiProvider, GiftUiProvider>();
            services.AddSingleton<IDisplayService, DisplayService>();
            services.AddSingleton<IUISignalHandler, UISignalHandler>();
            services.AddSingleton<GiftBase>();

            return services;
        }
    }
}
