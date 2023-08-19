
using Gift.Builders;
using Gift.src.Services.Displayer;
using Gift.UI;
using Gift.UI.Configuration;
using Gift.UI.Displayer;
using Gift.UI.Element;
using Gift.UI.MetaData;
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
