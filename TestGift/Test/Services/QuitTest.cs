﻿using Gift;
using Gift.src.Extensions;
using Gift.UI;
using Microsoft.Extensions.DependencyInjection;

namespace TestGift.Test.Services
{
    public class QuitTest
    {
        public QuitTest()
        {
            var services = new ServiceCollection();
            services.AddGiftTestServices();
            var serviceProvider = services.BuildServiceProvider();
            var gift = serviceProvider.GetRequiredService<GiftBase>();

            gift.Initialize(new GiftUI());
            gift.Run();
        }
    }
}
