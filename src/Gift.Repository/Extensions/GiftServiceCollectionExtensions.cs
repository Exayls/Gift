using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.ServiceContracts;
using Gift.Repository.Repository;

namespace Gift.Repository.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftRepository(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, InMemoryRepository>();
            return services;
        }
    }
}
