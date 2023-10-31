using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.Builders;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;

var ui = new GiftUIBuilder().Build();

var vstack = new VStackBuilder().WithBorder(new DetailedBorder(2, BorderOption.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
ui.AddUnselectableChild(vstack);
vstack.AddUnselectableChild(new LabelBuilder().WithText("test1").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test2").WithPosition(new Position(1,58)).Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test4").Build());
var vstack2 = new VStackBuilder().WithBound(new Bound(4,9)).WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
vstack.AddUnselectableChild(vstack2);
vstack.AddUnselectableChild(new LabelBuilder().WithText("test5").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test3").WithBackgroundColor(Color.Red).Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack2.AddUnselectableChild(new LabelBuilder().WithText("testwithbiggerwidth").Build());
vstack2.AddUnselectableChild(new LabelBuilder().Build());
vstack2.AddUnselectableChild(new LabelBuilder().Build());
vstack2.AddUnselectableChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2,58)).Build());



var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftService>();
gift.Initialize(ui);
gift.Run();
