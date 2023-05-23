using Gift;
using Gift.src.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.Test
{
    public class QuitTest
    {
        public QuitTest()
        {
            var services = new ServiceCollection();
            services.AddGiftTestServices();
            var serviceProvider = services.BuildServiceProvider();
            var gift = serviceProvider.GetRequiredService<GiftBase>();

            gift.Initialize();
            gift.Run();
        }
    }
}
