using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {

        var hostBuilder = new GiftHostBuilder("test.xml");
        hostBuilder.ConfigureAppConfiguration(
            (hostContext, builder) =>
            {
                builder.AddJsonFile("appsettings.json");
            });
        hostBuilder.ConfigureLogging(
            builder =>
            {
                var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();

                var logger = new LoggerConfiguration()
                                 .WriteTo.File($"logs/app_.log", rollingInterval: RollingInterval.Day)
                                 .ReadFrom.Configuration(configuration)
                                 .CreateLogger();

                builder.AddSerilog(logger);
            });
        var host = hostBuilder.Build();
        host.Run();
    }
}
