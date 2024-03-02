using Gift.ApplicationService.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using Gift.Startup.Extensions;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddGiftServices();
        Log.Logger = new LoggerConfiguration()
                         .WriteTo.File($"logs/Example4_.log", rollingInterval: RollingInterval.Day)
                         .MinimumLevel.Information()
                         .CreateLogger();
        services.AddLogging(builder =>
                            { builder.AddSerilog(); });
        var serviceProvider = services.BuildServiceProvider();
        var gift = serviceProvider.GetRequiredService<IGiftService>();

        gift.InitializeHotReload("test.xml");
        gift.Run();
    }
}
