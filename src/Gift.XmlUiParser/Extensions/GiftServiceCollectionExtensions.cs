using Microsoft.Extensions.DependencyInjection;
using Gift.ApplicationService.Services.FileParser;

namespace Gift.XmlUiParser.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftXmlParser(this IServiceCollection services)
        {
            services.AddSingleton<IUIElementRegister, UIElementRegister>();
            services.AddSingleton<IXMLFileParser, XmlFileParser>();
            return services;
        }
    }
}
