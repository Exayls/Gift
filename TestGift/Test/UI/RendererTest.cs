using Gift.Builders;
using Gift.Domain.UIModel.Border;
using Gift.UI;
using Gift.UI.Conf;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Gift.UI.Render;
using Xunit;

namespace TestGift.Test.UI
{
    public class RendererTest
    {
        private Renderer renderer;

        public RendererTest()
        {
            renderer = new Renderer(new DefaultConfiguration());
        }

        [Fact]
        public void Can_render_Simple_UI()
        {
            GiftUI ui = new GiftUI(new Bound(5, 10), new NoBorder());
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
            const string expected = "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********";
            Assert.Equal(expected,rendered.DisplayString.ToString() );
        }

        [Fact]
        public void Can_render_UI_with_relative_position()
        {
            GiftUI ui = new GiftUI(new Bound(10, 10), new NoBorder());

            VStack vstack = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
            vstack.AddUnselectableChild(new LabelBuilder().Build());
            ui.AddUnselectableChild(vstack);
            VStack vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
            vstack.AddUnselectableChild(vstack2);
            vstack2.AddUnselectableChild(new LabelBuilder().WithText("hey").Build());
            vstack2.AddUnselectableChild(new LabelBuilder().Build());
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
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
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }
        [Fact]
        public void Can_render_UI_with_relative_position_and_out_of_bound()
        {
            GiftUI ui = new GiftUI(new Bound(10, 10), new NoBorder());

            VStack vstack = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/double_border.json"))).Build();
            vstack.AddUnselectableChild(new LabelBuilder().Build());
            ui.AddUnselectableChild(vstack);
            VStack vstack2 = new VStackBuilder().WithBorder(new Border(1, BorderOption.GetBorderCharsFromFile("ressources/borderChars/simple_border.json"))).Build();
            vstack.AddUnselectableChild(vstack2);
            vstack2.AddUnselectableChild(new LabelBuilder().WithText("hey").Build());
            vstack2.AddUnselectableChild(new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 3)).Build());
            vstack2.AddUnselectableChild(new LabelBuilder().Build());
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
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
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }
    }
}
