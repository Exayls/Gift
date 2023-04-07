using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.MetaData;

var ui = new GiftUI();

var vstack = new VStackBuilder().WithBorder(new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
ui.SetChild(vstack);
vstack.AddChild(new LabelBuilder().WithText("test1").BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().WithText("test2").WithPosition(new Position(1,58)).Build());
vstack.AddChild(new LabelBuilder().WithText("test4").BuildImplicit());
var vstack2 = new VStackBuilder().WithBound(new Bound(4,9)).WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
vstack.AddChild(vstack2);
vstack.AddChild(new LabelBuilder().WithText("test5").BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack.AddChild(new LabelBuilder().WithText("test3").BuildImplicit());
vstack.AddChild(new LabelBuilder().BuildImplicit());
vstack2.AddChild(new LabelBuilder().WithText("testwithbiggerwidth").BuildImplicit());
vstack2.AddChild(new LabelBuilder().BuildImplicit());
vstack2.AddChild(new LabelBuilder().BuildImplicit());
vstack2.AddChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2,58)).Build());



var gift = new GiftBase(new RelativeRenderer());
gift.initialize(ui);
gift.run();
