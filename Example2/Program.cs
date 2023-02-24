using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.MetaData;

var ui = new GiftUI();

var vstack = new VStackBuilder().WithBorder(new SimpleBorder(1, '+')).Build();
ui.SetChild(vstack);
vstack.AddChild(new Label("coucou", new Position(2, 58)));
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
