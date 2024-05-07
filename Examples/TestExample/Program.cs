using Gift.ApplicationService.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gift.Startup.Extensions;
using Serilog;
using System.Threading.Tasks;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        Log.Logger = new LoggerConfiguration()
                         .WriteTo.File($"logs/HotReloadExample.log", rollingInterval: RollingInterval.Day)
                         .MinimumLevel.Debug()
                         .CreateLogger();
        services.AddLogging(builder =>
                            { builder.AddSerilog(); });
        var serviceProvider = services.BuildServiceProvider();
        // var gift = serviceProvider.GetRequiredService<IGiftService>();

		IHostBuilder builder = Host.CreateDefaultBuilder();
		builder.ConfigureServices(services =>
		{
			services.AddGiftServices();
			services.AddHostedService<Worker>();
		});

		IHost host = builder.Build();
		host.Run();
    }
}

public class Worker : IHostedService
{
    private IGiftService _giftService;

    public Worker(IGiftService giftService){
		_giftService = giftService;
	}

    public Task StartAsync(CancellationToken cancellationToken)
    {
		_giftService.Initialize("test.xml");
		// var task = Task.Run(()=> _giftService.Run());
		var task = Task.CompletedTask;
		_giftService.Run();
		return task;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
		return Task.CompletedTask;
    }
}
