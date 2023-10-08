using Microsoft.Extensions.DependencyInjection;
using Gift.Domain.ServiceContracts;
using Gift.XmlUiParser.FileParser;

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
