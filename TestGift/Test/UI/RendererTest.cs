﻿using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace TestGift.Test.UI
{
    public class RendererTest
    {
        private Renderer Renderer;

        public RendererTest()
        {
            Renderer = new Renderer();
        }

        [Fact]
        public void Can_render_Simple_UI()
        {
            GiftUI ui = new GiftUI(new Bound(5, 10), new NoBorder());
            TextWriter rendered = Renderer.GetRenderedBuffer(ui);
            const string expected = "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********";
            Assert.Equal(expected,rendered.ToString() );
        }

        [Fact]
        public void Can_render_UI_with_relative_position()
        {
            GiftUI ui = new GiftUI(new Bound(10, 10), new NoBorder());

            VStack vstack = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
            vstack.AddChild(new LabelBuilder().BuildImplicit());
            ui.SetChild(vstack);
            VStack vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
            vstack.AddChild(vstack2);
            vstack2.AddChild(new LabelBuilder().WithText("hey").BuildImplicit());
            vstack2.AddChild(new LabelBuilder().BuildImplicit());
            TextWriter rendered = Renderer.GetRenderedBuffer(ui);
            const string expected = "╔════════╗\n" +
                                    "║Hello***║\n" +
                                    "║┌─────┐*║\n" +
                                    "║│hey**│*║\n" +
                                    "║│Hello│*║\n" +
                                    "║└─────┘*║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "╚════════╝";
            Assert.Equal(expected, rendered.ToString());
        }

        //[Fact]
        //public void Can_render_UI_with_relative_position_and_out_of_bound()
        //{
        //    GiftUI ui = new GiftUI(new Bound(10, 10), new NoBorder());

        //    VStack vstack = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
        //    vstack.AddChild(new LabelBuilder().BuildImplicit());
        //    ui.SetChild(vstack);
        //    VStack vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderChars.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
        //    vstack.AddChild(vstack2);
        //    vstack2.AddChild(new LabelBuilder().WithText("testwithbiggerwidth").BuildImplicit());
        //    vstack2.AddChild(new LabelBuilder().BuildImplicit());
        //    vstack2.AddChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 3)).Build());
        //    RelativeRenderer relativeRenderer = new RelativeRenderer();
        //    rendered = relativeRenderer.GetRenderedBuffer(ui);
        //    const string expected = "╔════════╗\n" +
        //                            "║hello***║\n" +
        //                            "║┌──┐****║\n" +
        //                            "║│**│****║\n" +
        //                            "║└──┘****║\n" +
        //                            "║********║\n" +
        //                            "║********║\n" +
        //                            "║********║\n" +
        //                            "║********║\n" +
        //                            "╚════════╝";
        //    Assert.Equal(expected, rendered.ToString());
        //}
    }
}