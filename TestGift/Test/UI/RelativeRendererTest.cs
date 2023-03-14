﻿using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace TestGift.Test.UI
{
    public class RelativeRendererTest
    {
        private TextWriter rendered;

        public RelativeRendererTest()
        {
            GiftUI ui = new GiftUI(new Bound(5, 10));

            VStack vstack = new VStackBuilder().WithBorder(new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
            vstack.AddChild(new LabelBuilder().BuildImplicit());
            ui.SetChild(vstack);
            VStack vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
            vstack.AddChild(vstack2);
            vstack2.AddChild(new LabelBuilder().WithText("testwithbiggerwidth").BuildImplicit());
            vstack2.AddChild(new LabelBuilder().BuildImplicit());
            vstack2.AddChild(new LabelBuilder().BuildImplicit());
            vstack2.AddChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 58)).Build());

        }

        [Fact]
        public void Can_render_Simple_UI()
        {
            GiftUI ui = new GiftUI(new Bound(5, 10), new NoBorder());
            RelativeRenderer relativeRenderer = new RelativeRenderer();
            rendered = relativeRenderer.GetRenderedBuffer(ui);
            const string expected = "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********";
            Assert.Equal(expected,rendered.ToString() );
        }



    }
}
