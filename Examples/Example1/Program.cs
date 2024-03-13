using Gift.Displayer.Displayer;
using Gift.Displayer.Rendering;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.MetaData;

var ui = new GiftUIBuilder().Build();
ui.AddUnselectableChild(new LabelBuilder().WithText("coucou").WithPosition(new Position(2, 58)).Build());

var vstack = new VStackBuilder().Build();
ui.AddUnselectableChild(vstack);
vstack.AddUnselectableChild(new LabelBuilder().WithText("coucou").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("tieaucit").WithPosition(new Position(1, 58)).Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());
vstack.AddUnselectableChild(new LabelBuilder().WithText("tieaucit").Build());
vstack.AddUnselectableChild(new LabelBuilder().Build());

new ConsoleDisplayer(new ConsoleDisplayStringFormater())
    .Display(new Renderer(new DefaultConfiguration(),  new Gift.Displayer.Rendering.ColorResolver()).GetRenderDisplay(ui));

// var gift = new GiftBase();
// gift.initialize();
// gift.run();
