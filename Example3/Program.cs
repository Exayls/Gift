﻿using Gift;
using Gift.Builders;
using Gift.src.Extension;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.MetaData;
using Gift.UI.Render;
using Microsoft.Extensions.DependencyInjection;

var ui = new GiftUI();

var vstack = new VStackBuilder().WithBorder(new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
ui.AddChild(vstack);
vstack.AddChild(new LabelBuilder().WithText("test1").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithText("test2").WithPosition(new Position(1,58)).Build());
vstack.AddChild(new LabelBuilder().WithText("test4").Build());
var vstack2 = new VStackBuilder().WithBound(new Bound(4,9)).WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
vstack.AddChild(vstack2);
vstack.AddChild(new LabelBuilder().WithText("test5").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithBackgroundColor(Color.Red).WithText("test3").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack2.AddChild(new LabelBuilder().WithText("testwithbiggerwidth").Build());
vstack2.AddChild(new LabelBuilder().Build());
vstack2.AddChild(new LabelBuilder().Build());
vstack2.AddChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2,58)).Build());



var services = new ServiceCollection();
services.AddGiftServices();
var serviceProvider = services.BuildServiceProvider();
var gift = serviceProvider.GetRequiredService<GiftBase>();
gift.Initialize(ui);
gift.Run();
