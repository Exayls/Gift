using System.Globalization;
using Gift.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
    private static void Main()
    {
        var hostBuilder = new GiftHostBuilder();

        hostBuilder.ConfigureAppConfiguration(
            (hostContext, builder) =>
            {
                builder.AddJsonFile("appsettings.json");
            });

        hostBuilder.ConfigureLogging(
            (hostContext, builder) =>
            {
                var logger = new LoggerConfiguration()
                                 .WriteTo.File($"logs/Example4_.log", rollingInterval: RollingInterval.Day, formatProvider: CultureInfo.InvariantCulture)
                                 .ReadFrom.Configuration(hostContext.Configuration)
                                 .CreateLogger();

                builder.AddSerilog(logger);
            });
        var host = hostBuilder.Build();
        host.Run();
    }
}
