using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.UIModel.Conf;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services;
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
            services.AddSingleton<IKeyMapper, KeyMapper>();
            services.AddSingleton<IMonitorService, MonitorService>();
            services.AddSingleton<ISignalBus, SignalBus>();
            services.AddSingleton<IGiftService, GiftLauncherService>();
            services.AddSingleton<IUISignalHandler, UISignalHandler>();
            services.AddSingleton<IKeySignalHandler, KeySignalHandler>();
            services.AddSingleton<IGlobalSignalHandler, GlobalSignalHandler>();
            services.AddSingleton<ILifeTimeService, LifeTimeService>();

            return services;
        }
    }
}
