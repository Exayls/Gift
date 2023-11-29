using Gift.ApplicationService.ServiceContracts;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftService>();
var log = serviceProvider.GetRequiredService<ILogger<IGiftService>>();
log.LogDebug("iuaeite");
gift.Initialize("test.xml");
gift.Run();
