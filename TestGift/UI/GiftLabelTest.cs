
using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System.Text;

namespace TestGift.UI
{
    public class GiftLabelTest
    {
        [Fact]
        public void TestLabelOutputFull()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var element = new LabelBuilder().Build();
                ui.SetChild(element);
                new Renderer().Render(ui);

                var str = TestHelper.GetElementString(element);
                Assert.Equal("Hello", str[0]);
            }
        }
        [Fact]
        public void TestLabelOutputEmpty()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var element = new LabelBuilder().WithPosition(new Position(0, 100)).Build();
                ui.SetChild(element);
                new Renderer().Render(ui);

                var str = TestHelper.GetElementString(element);
                Assert.Equal("", str[0]);
            }
        }
        [Fact]
        public void TestLabelOutputBeetween()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var element = new LabelBuilder().WithPosition(new Position(0, 58)).Build();
                ui.SetChild(element);
                new Renderer().Render(ui);

                var str = TestHelper.GetElementString(element);
                Assert.Equal("He", str[0]);
            }
        }
    }
}
