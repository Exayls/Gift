using Gift;
using Gift.src.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<GiftBase>();

gift.Initialize("test.xml");
gift.Run();
