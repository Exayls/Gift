using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
                         .WriteTo.File($"logs/app_.log", rollingInterval: RollingInterval.Day)
                         .MinimumLevel.Debug()
                         .CreateLogger();

		var hostBuilder = new GiftHostBuilder("test.xml");
		hostBuilder.ConfigureLogging(builder =>
                            { builder.AddSerilog(); });
		var host = hostBuilder.Build();
		host.Run();
    }
}

