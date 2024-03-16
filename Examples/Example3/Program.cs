using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var ui = new GiftUIBuilder().Build();

var vstack = new VStackBuilder().WithBorder(new DetailedBorder(2, BorderOption.GetBorderCharsFromFile("ressources/borderchars/double_border.json"))).Build();
ui.Add(vstack);
vstack.Add(new LabelBuilder().WithText("test1").Build());
vstack.Add(new LabelBuilder().Build());
vstack.Add(new LabelBuilder().Build());
vstack.Add(new LabelBuilder().WithText("test2").WithPosition(new Position(1, 58)).Build());
vstack.Add(new LabelBuilder().WithText("test4").Build());
var vstack2 = new VStackBuilder().WithBound(new Bound(4, 9)).WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"))).Build();
vstack.Add(vstack2);
vstack.Add(new LabelBuilder().WithText("test5").Build());
vstack.Add(new LabelBuilder().Build());
vstack.Add(new LabelBuilder().WithText("test3").WithBackgroundColor(Color.Red).Build());
vstack.Add(new LabelBuilder().Build());
vstack2.Add(new LabelBuilder().WithText("testwithbiggerwidth").Build());
vstack2.Add(new LabelBuilder().Build());
vstack2.Add(new LabelBuilder().Build());
vstack2.Add(new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 58)).Build());



var services = new ServiceCollection();
Log.Logger = new LoggerConfiguration()
                 .WriteTo.File($"logs/Example4_.log", rollingInterval: RollingInterval.Day)
                 .MinimumLevel.Information()
                 .CreateLogger();
services.AddLogging(builder =>
                    { builder.AddSerilog(); });
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftService>();
gift.Initialize(ui);
gift.Run();
