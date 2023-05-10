﻿using Gift;
using Gift.Builders;
using Gift.src.Extension;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.MetaData;
using Gift.UI.Render;
using Microsoft.Extensions.DependencyInjection;

var ui = new GiftUI();

var hstack = new HStackBuilder().WithBorder(new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
ui.AddChild(hstack);

var vstack = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
hstack.AddChild(vstack);
hstack.AddChild(new LabelBuilder().WithText("test7").Build());
hstack.AddChild(new LabelBuilder().WithText("test8").Build());

vstack.AddChild(new LabelBuilder().WithText("test1").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithText("test2").WithPosition(new Position(1, 58)).Build());
vstack.AddChild(new LabelBuilder().WithText("test4").Build());

var vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
vstack.AddChild(vstack2);
var element1 = new LabelBuilder().WithText("testwithbiggerwidth").Build();
vstack2.AddChild(element1);
var element2 = new LabelBuilder().Build();
vstack2.AddChild(element2);
var element3 = new LabelBuilder().Build();
vstack2.AddChild(element3);
var element4 = new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 58)).Build();
vstack2.AddChild(element4);

vstack2.SelectableElements.Add(element1);
vstack2.SelectableElements.Add(element2);
vstack2.SelectableElements.Add(element3);
vstack2.SelectableElements.Add(element4);
vstack2.SelectedElement = element1;


vstack.AddChild(new LabelBuilder().WithText("test5").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithText("test3").Build());
vstack.AddChild(new LabelBuilder().Build());

ui.SelectableContainers.Add(vstack2);
ui.SelectedContainer = vstack2;




var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetService<GiftBase>();
gift.Initialize(ui);
gift.Run();
