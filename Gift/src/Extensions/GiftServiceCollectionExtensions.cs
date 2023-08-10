using Gift.KeyInput;
using Gift.Monitor;
using Gift.src.Services.Displayer;
using Gift.src.Services.FileParser;
using Gift.src.Services.Monitor.ConsoleMonitors;
using Gift.src.Services.SignalHandler.Bus;
using Gift.src.Services.SignalHandler.Global;
using Gift.src.Services.SignalHandler.Key;
using Gift.src.Services.SignalHandler.Ui;
using Gift.src.UIModel;
using Gift.UI.Configuration;
using Gift.UI.Displayer;
using Gift.UI.DisplayManager;
using Gift.UI.Render;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<IConsoleSizeMonitor, ConsoleSizeMonitor>();
            services.AddSingleton<IMonitorManager, MonitorManager>();
            services.AddSingleton<ISignalBus, SignalBus>();
            services.AddSingleton<IGiftUiProvider, GiftUiProvider>();
            services.AddSingleton<IDisplayManager, DisplayManager>();
            services.AddSingleton<IUISignalHandler, UISignalHandler>();
            services.AddSingleton<IKeySignalHandler, KeySignalHandler>();
            services.AddSingleton<IGlobalSignalHandler, GlobalSignalHandler>();
            services.AddSingleton<IUIElementRegister, UIElementRegister>();
            services.AddSingleton<IXMLFileParser, XmlFileParser>();
            services.AddSingleton<GiftBase>();


            return services;
        }
    }
}
