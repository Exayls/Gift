using Gift;
using Gift.Domain.UIModel;
using Gift.src.Extensions;
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
            var gift = serviceProvider.GetRequiredService<GiftLauncher>();

            gift.Initialize(new GiftUI());
            gift.Run();
        }
    }
}
