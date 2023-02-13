
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
            List<string> str = GetLabelStr(new Bound(20, 60), createLabel());
            Assert.Equal("Hello", str[0]);
        }


        [Fact]
        public void TestLabelOutputEmpty()
        {
            List<string> str = GetLabelStr(new Bound(20, 60), createLabel(new Position(0, 100)));
            Assert.Equal("", str[0]);
        }


        [Fact]
        public void TestLabelOutputBeetween()
        {
            List<string> str = GetLabelStr(new Bound(20, 60), createLabel(new Position(0, 58)));
            Assert.Equal("He", str[0]);
        }

        private static Label createLabel(Position positionLabel)
        {
            return new LabelBuilder().WithPosition(positionLabel).Build();
        }

        private static Label createLabel()
        {
            return new LabelBuilder().Build();
        }

        private static List<string> GetLabelStr(Bound boundUI, Label label)
        {
            List<string> str;
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var element = GetLabelWithUIContext(boundUI, label);
                str = TestHelper.GetElementString(element);
            }
            return str;
        }

        private static Label GetLabelWithUIContext(Bound boundUI, Label label)
        {
            var ui = new GiftUI(boundUI);
            Label element = label;
            ui.SetChild(element);
            return element;
        }
    }
}
