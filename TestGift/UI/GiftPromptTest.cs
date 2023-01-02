
using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System.Text;

namespace TestGift.UI
{
    public class GiftPromptTest
    {
        [Fact]
        public void CanDisplayTextToPosNeutral()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var element = new LabelBuilder().Build();
                ui.setChild(element);
                ui.Render();

                Assert.Equal("Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayTextToPosFirstLineAt30()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var position = new Position(0, 30);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("                              Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayTextToPosFirstLineAt10()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var position = new Position(0, 10);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("          Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayText2ToPosFirstLineAt10()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var position = new Position(0, 10);
                var element = new LabelBuilder().WithText("test").WithPosition(position).Build();
                ui.setChild(element);

                ui.Render();

                Assert.Equal("          test", output.ToString());
            }
        }
        [Fact]
        public void DoNotDisplayExcedingBounds60()
        {
           var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var position = new Position(0, 1000);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("".PadLeft(60), output.ToString());
            }
        }
        [Fact]
        public void DoNotDisplaybarelyExcedingBounds60()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var position = new Position(0, 58);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("".PadLeft(58)+ "He", output.ToString());
            }
        }
        [Fact]
        public void DoNotDisplaybarelyExcedingBounds80()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer), new Bound(10, 80));
                var position = new Position(0, 58);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("".PadLeft(58)+ "Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayTextToPos()

        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer), new Bound(4,16));
                var position = new Position(2, 10);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("                \n                \n          Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayTextToPos2()

        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer), new Bound(4,16));
                var position = new Position(1, 10);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("                \n          Hello", output.ToString());
            }
        }
        [Fact]
        public void CanDisplayTextToPos3()

        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer), new Bound(4,32));
                var position = new Position(1, 10);
                var element = new LabelBuilder().WithPosition(position).Build();
                ui.setChild(element);
                ui.Render();
                Assert.Equal("                                \n          Hello", output.ToString());
            }
        }
    }
}
