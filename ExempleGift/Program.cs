﻿
using Gift;
using Gift.Builders;
using Gift.src.Services.Displayer;
using Gift.UI;
using Gift.UI.Configuration;
using Gift.UI.Displayer;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Gift.UI.Render;


var ui = new GiftUI();
ui.AddChild(new Label("coucou", new Position(2, 58)));

var vstack = new VStackBuilder().Build();
ui.AddChild(vstack);
vstack.AddChild(new LabelBuilder().WithText("coucou").Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithText("tieaucit").WithPosition(new Position(1,58)).Build());
vstack.AddChild(new LabelBuilder().Build());
vstack.AddChild(new LabelBuilder().WithText("tieaucit").Build());
vstack.AddChild(new LabelBuilder().Build());

new ConsoleDisplayer(new ConsoleDisplayStringFormater()).display(new Renderer(new DefaultConfiguration()).GetRenderDisplay(ui));


//var gift = new GiftBase();
//gift.initialize();
//gift.run();
