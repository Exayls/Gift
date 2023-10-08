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
using Gift.XmlUiParser.Extensions;
using Gift.ApplicationService.Extensions;
using Gift.Displayer.Extensions;

namespace Gift.Startup.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftServices(this IServiceCollection services)
        {
            services.AddGiftApplicationServices();
            services.AddGiftDisplayer();
            services.AddGiftXmlParser();

            return services;
        }
    }
}
