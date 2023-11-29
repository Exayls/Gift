using Microsoft.Extensions.DependencyInjection;
using Gift.XmlUiParser.Extensions;
using Gift.ApplicationService.Extensions;
using Gift.Displayer.Extensions;
using Gift.ConsoleMonitor.Extensions;
using Gift.Domain.Extensions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using Serilog;

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

            var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name ?? "GiftApp";

            if (!services.Any(s => s.ServiceType == typeof(ILogger<>)))
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File($"a.log", rollingInterval: RollingInterval.Day)
                       .MinimumLevel.Debug()
                    .CreateLogger();

                services.AddLogging(builder =>
                {
                    builder.AddSerilog();
                });
            }

            return services;
        }
    }
}
