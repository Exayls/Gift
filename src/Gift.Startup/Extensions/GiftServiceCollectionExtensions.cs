using Microsoft.Extensions.DependencyInjection;
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
