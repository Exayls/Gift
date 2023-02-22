using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;


var ui = new GiftUI();
ui.SetChild(new Label("coucou", new Position(2, 58)));

var vstack = new VStackBuilder().Build();
ui.SetChild(vstack);
vstack.AddChild(new LabelBuilder().WithText("coucou").BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().WithText("tieaucit").WithPosition(new Position(1,58)).Build());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().WithText("tieaucit").BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());



var gift = new GiftBase(new Renderer());
gift.initialize(ui);
gift.run();
