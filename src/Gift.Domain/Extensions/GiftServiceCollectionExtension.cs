
using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.Builders.Mappers;

namespace Gift.Domain.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IBoundMapper, BoundMapper>();
            services.AddSingleton<IBorderMapper, BorderMapper>();
            services.AddSingleton<IColorMapper, ColorMapper>();
            return services;
        }
    }
}
