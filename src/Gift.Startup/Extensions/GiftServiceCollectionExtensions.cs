using Microsoft.Extensions.DependencyInjection;
using Gift.XmlUiParser.Extensions;
using Gift.ApplicationService.Extensions;
using Gift.Displayer.Extensions;
using Gift.ConsoleMonitor.Extensions;
using Gift.Domain.Extensions;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Gift.Startup.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftServices(this IServiceCollection services)
        {
            services.AddGiftApplicationServices();
            services.AddGiftDisplayer();
            services.AddGiftXmlParser();
            services.AddGiftKeyInteraction();
            services.AddGiftConsoleMonitor();
            services.AddDomainServices();

            if (!services.Any(s => s.ServiceType == typeof(ILogger<>)))
            {
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                });
            }
            return services;
        }
    }
}
