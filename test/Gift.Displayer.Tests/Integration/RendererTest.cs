using Gift.Displayer.Rendering;
using Gift.Domain.Builders;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace TestGift.Test.UI
{
    public class RendererTest
    {
        private Renderer renderer;

        public RendererTest() { renderer = new Renderer(new DefaultConfiguration()); }

        [Fact]
        public void Can_render_Simple_UI()
        {
            GiftUI ui = CreateGiftUi(new Bound(5, 10), new NoBorder());
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
            const string expected = "**********\n" + "**********\n" + "**********\n" +
                                    "**********\n" + "**********";
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }

        private static GiftUI CreateGiftUi(Bound bound, IBorder border)
        {
            return new GiftUIBuilder().WithBound(bound).WithBorder(border).Build();
        }

        [Fact]
        public void Can_render_UI_with_elements()
        {
            GiftUI ui = CreateGiftUi(new Bound(10, 10), new NoBorder());

            VStack vstack =
                new VStackBuilder()
                    .WithBorder(new DetailedBorder(
                        1, BorderOption.GetBorderCharsFromFile(
                               "ressources/borderchars/double_border.json")))
                    .Build();
            vstack.AddUnselectableChild(new LabelBuilder().Build());
            ui.AddUnselectableChild(vstack);
            VStack vstack2 =
                new VStackBuilder()
                    .WithBorder(new DetailedBorder(
                        1, BorderOption.GetBorderCharsFromFile(
                               "ressources/borderchars/simple_border.json")))
                    .Build();
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
        public void Can_render_UI_with_elements_out_of_bound()
        {
            GiftUI ui = CreateGiftUi(new Bound(10, 10), new NoBorder());

            VStack vstack =
                new VStackBuilder()
                    .WithBorder(new DetailedBorder(
                        1, BorderOption.GetBorderCharsFromFile(
                               "ressources/borderchars/double_border.json")))
                    .Build();
            vstack.AddUnselectableChild(new LabelBuilder().Build());
            ui.AddUnselectableChild(vstack);
            VStack vstack2 =
                new VStackBuilder()
                    .WithBorder(new DetailedBorder(
                        1, BorderOption.GetBorderCharsFromFile(
                               "ressources/borderchars/simple_border.json")))
                    .Build();
            vstack.AddUnselectableChild(vstack2);
            vstack2.AddUnselectableChild(new LabelBuilder().WithText("hey").Build());
            vstack2.AddUnselectableChild(new LabelBuilder()
                                             .WithText("test6")
                                             .WithPosition(new Position(-2, 3))
                                             .Build());
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
