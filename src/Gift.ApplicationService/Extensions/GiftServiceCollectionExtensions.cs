using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.Monitor.ConsoleMonitors;
using Gift.ApplicationService.Services;
using Gift.ApplicationService.Services.KeyInputHandler;
using Gift.ApplicationService.Services.Monitor;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;

namespace Gift.ApplicationService.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration, DefaultConfiguration>();
            services.AddSingleton<IDisplayService, DisplayService>();
            services.AddSingleton<IKeyInputHandler, KeyInputHandler>();
            services.AddSingleton<IKeyMapper, KeyMapper>();
            services.AddSingleton<IConsoleSizeMonitor, ConsoleSizeMonitor>();
            services.AddSingleton<IMonitorManager, MonitorManager>();
            services.AddSingleton<ISignalBus, SignalBus>();
            services.AddSingleton<IGiftUiProvider, GiftUiProvider>();
            services.AddSingleton<IGiftLauncher, GiftLauncher>();
            services.AddSingleton<IUISignalHandler, UISignalHandler>();
            services.AddSingleton<IKeySignalHandler, KeySignalHandler>();
            services.AddSingleton<IGlobalSignalHandler, GlobalSignalHandler>();

            return services;
        }
    }
}
