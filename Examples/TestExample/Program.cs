using Gift.ApplicationService.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using Gift.Startup.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddGiftServices();
        var serviceProvider = services.BuildServiceProvider();
        var gift = serviceProvider.GetRequiredService<IGiftService>();

        gift.InitializeHotReload("test.xml");
        gift.Run();
    }
}
