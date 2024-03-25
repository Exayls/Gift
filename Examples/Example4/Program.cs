using Gift.ApplicationService.ServiceContracts;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var services = new ServiceCollection();
services.AddGiftServices();

Log.Logger = new LoggerConfiguration()
                 .WriteTo.File($"logs/Example4_.log", rollingInterval: RollingInterval.Day)
                 .MinimumLevel.Debug()
                 .CreateLogger();
services.AddLogging(builder =>
                    { builder.AddSerilog(); });

var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftService>();
gift.Initialize("test.xml");
gift.Run();
