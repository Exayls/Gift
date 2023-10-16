using Microsoft.Extensions.DependencyInjection;
using Gift.Displayer.Displayer;
using Gift.Displayer.Rendering;
using Gift.Domain.ServiceContracts;

namespace Gift.Displayer.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftDisplayer(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleDisplayStringFormater, ConsoleDisplayStringFormater>();
            services.AddSingleton<IDisplayer, ConsoleDisplayer>();
            services.AddSingleton<IRenderer, Renderer>();

            return services;
        }
    }
}
