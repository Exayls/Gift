using Gift.ApplicationService.ServiceContracts;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftService>();

gift.Initialize("test.xml");
gift.Run();
