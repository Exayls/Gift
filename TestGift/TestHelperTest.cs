using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift
{
    public class TestHelperTest
    {
        [Fact]
        public void TestHelperLabelTest()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var element = new LabelBuilder().Build();
                ui.setChild(element);
                ui.Render();

                var str = TestHelper.GetElementString(element);
                Assert.Equal("Hello", str[0]);
            }
        }
        [Fact]
        public void TestHelperLabelTestOut()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer));
                var element = new LabelBuilder().WithPosition(new Position(0, 100)).Build();
                ui.setChild(element);
                ui.Render();

                var str = TestHelper.GetElementString(element);
                Assert.Equal("", str[0]);
            }
        }
    }
}
