﻿using Microsoft.Extensions.DependencyInjection;
using Gift.XmlUiParser.Extensions;
using Gift.ApplicationService.Extensions;
using Gift.Displayer.Extensions;
using Gift.ConsoleMonitor.Extensions;
using Gift.Repository.Extensions;
using Gift.Domain.Extensions;
using Gift.KeyInteraction.Extensions;

namespace Gift.Startup.Extensions
{
    public static class GiftServiceCollectionExtensions
    {
        public static IServiceCollection AddGiftServices(this IServiceCollection services)
        {
            services.AddGiftApplicationServices();
            services.AddGiftDisplayer();
            services.AddGiftXmlParser();
            services.AddGiftKeyInteraction();
            services.AddGiftConsoleMonitor();
            services.AddGiftRepository();
            services.AddDomainServices();
            services.AddLogging();
            return services;
        }
    }
}
