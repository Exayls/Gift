using Microsoft.Extensions.DependencyInjection;
using Gift.ConsoleMonitor.ConsoleMonitors;
using Gift.Domain.ServiceContracts;

namespace Gift.ConsoleMonitor.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftConsoleMonitor(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleSizeMonitor, ConsoleSizeMonitor>();

            services.AddSingleton<IMonitor>(provider => provider.GetRequiredService<IConsoleSizeMonitor>());


            return services;
        }
    }
}
