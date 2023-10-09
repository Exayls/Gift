using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.Builders;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using Gift.Startup.Extensions;
using Microsoft.Extensions.DependencyInjection;

var ui = new GiftUI();

var hstack = new HStackBuilder().WithBorder(new Border(2, BorderOption.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
ui.AddUnselectableChild(hstack);

var vstack = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
hstack.AddUnselectableChild(vstack);
hstack.AddUnselectableChild(new LabelBuilder().WithText("test7").Build());
hstack.AddUnselectableChild(new LabelBuilder().WithText("test8").Build());

vstack.AddUnselectableChild(new LabelBuilder().WithText("test1").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test2").WithPosition(new Position(1, 58)).Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test4").Build());

var vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
vstack.AddUnselectableChild(vstack2);
var element1 = new LabelBuilder().WithText("testwithbiggerwidth").Build();
vstack2.AddUnselectableChild(element1);
var element2 = new LabelBuilder().Build();
vstack2.AddUnselectableChild(element2);
var element3 = new LabelBuilder().Build();
vstack2.AddUnselectableChild(element3);
var element4 = new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 58)).Build();
vstack2.AddUnselectableChild(element4);

vstack2.SelectableElements.Add(element1);
vstack2.SelectableElements.Add(element2);
vstack2.SelectableElements.Add(element3);
vstack2.SelectableElements.Add(element4);
vstack2.SelectedElement = element1;


vstack.AddUnselectableChild(new LabelBuilder().WithText("test5").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("test3").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());

ui.SelectableContainers.Add(vstack2);
ui.SelectedContainer = vstack2;




var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<IGiftLauncherService>();
gift.Initialize(ui);
gift.Run();
