using Gift.ApplicationService.ServiceContracts;
using Gift.src.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftLauncher>();

gift.Initialize("test.xml");
gift.Run();
