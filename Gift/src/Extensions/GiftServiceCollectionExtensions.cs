using Gift.Bus;
using Gift.KeyInput;
using Gift.Monitor;
using Gift.SignalHandler;
using Gift.src.Services.Displayer;
using Gift.src.Services.Monitor;
using Gift.src.Services.SignalHandler.Key;
using Gift.src.UIModel;
using Gift.UI.Configuration;
using Gift.UI.Displayer;
using Gift.UI.DisplayManager;
using Gift.UI.Render;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.src.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration, DefaultConfiguration>();
            services.AddSingleton<IRenderer, Renderer>();
            services.AddSingleton<IDisplayManager, DisplayManager>();
            services.AddSingleton<IConsoleDisplayStringFormater, ConsoleDisplayStringFormater>();
            services.AddSingleton<IDisplayer, ConsoleDisplayer>();
            services.AddSingleton<IKeyInputHandler, KeyInputHandler>();
            services.AddSingleton<IKeyMapper, KeyMapper>();
            services.AddSingleton<IKeySignalHandler, KeySignalHandler>();
            services.AddSingleton<IConsoleSizeMonitor, ConsoleSizeMonitor>();
            services.AddSingleton<IMonitorManager, MonitorManager>();
            services.AddSingleton<ISignalBus, SignalBus>();
            services.AddSingleton<IGiftUiProvider, GiftUiProvider>();
            services.AddSingleton<IDisplayManager, DisplayManager>();
            services.AddSingleton<IUISignalHandler, UISignalHandler>();
            services.AddSingleton<GiftBase>();

            return services;
        }
    }
}
