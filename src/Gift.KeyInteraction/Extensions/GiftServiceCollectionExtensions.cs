using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.ServiceContracts;
using Gift.KeyInteraction.KeyInteraction;

namespace Gift.KeyInteraction.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftKeyInteraction(this IServiceCollection services)
        {
            services.AddSingleton<IKeyInteractionMonitor, KeyInteractionMonitor>();

            services.AddSingleton<IMonitor>(provider => provider.GetRequiredService<IKeyInteractionMonitor>());

            return services;
        }
    }
}
