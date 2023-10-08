using Microsoft.Extensions.DependencyInjection;
using Gift.ApplicationService.Services.Displayer;
using Gift.ApplicationService.Services.Renderer;

namespace Gift.src.Extensions
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
