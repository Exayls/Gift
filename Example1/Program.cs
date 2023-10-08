﻿
using Gift.Builders;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.src.Services.Displayer;
using Gift.UI.Conf;
using Gift.UI.Displayer;
using Gift.UI.Render;


var ui = new GiftUI();
ui.AddUnselectableChild(new Label("coucou", new Position(2, 58)));

var vstack = new VStackBuilder().Build();
ui.AddUnselectableChild(vstack);
vstack.AddUnselectableChild(new LabelBuilder().WithText("coucou").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("tieaucit").WithPosition(new Position(1,58)).Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("tieaucit").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());

new ConsoleDisplayer(new ConsoleDisplayStringFormater()).display(new Renderer(new DefaultConfiguration()).GetRenderDisplay(ui));


//var gift = new GiftBase();
//gift.initialize();
//gift.run();
