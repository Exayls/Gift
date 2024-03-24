
using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;

namespace Gift.Domain.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IBoundMapper, BoundMapper>();
            services.AddSingleton<IBorderMapper, BorderMapper>();
            services.AddSingleton<IColorMapper, ColorMapper>();
            services.AddSingleton<IBooleanMapper, BoolMapper>();
            services.AddSingleton<IElementSizeCalculator, TrueElementSizeCalculator>();
            services.AddSingleton<IColorResolver, ColorResolver>();
            return services;
        }
    }
}
