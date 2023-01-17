using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UI
{
    public class GiftVStackTest
    {
        [Fact]
        public void TestVStack()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var vstack = new VStackBuilder().Build();
                ui.SetChild(vstack);
                TextWriter renderedText= new Renderer(writer).Render(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
                for (int i = 0; i < ui.Bound.Height; i++)
                {
                    expectedBuilder.Clear();
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                    expected = expectedBuilder.ToString();
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
        [Fact]
        public void TestVStackWithLabelImplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var vstack = new VStackBuilder().Build();
                var label = new LabelBuilder().BuildImplicit();
                ui.SetChild(vstack);
                vstack.AddChild(label);
                TextWriter renderedText= new Renderer(writer).Render(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
                for (int i = 0; i < ui.Bound.Height; i++)
                {
                    expectedBuilder.Clear();
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                    expected = expectedBuilder.ToString();
                    if (i == 0)
                    {
                        expected = TestHelper.Replace(expected, "Hello", 0);
                    }
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
        [Fact]
        public void TestVStackWithLabelExplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20,60));
                var vstack = new VStackBuilder().Build();
                var label = new LabelBuilder().Build();
                ui.SetChild(vstack);
                vstack.AddChild(label);
                TextWriter renderedText= new Renderer(writer).Render(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
                for (int i = 0; i < ui.Bound.Height; i++)
                {
                    expectedBuilder.Clear();
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                    expected = expectedBuilder.ToString();
                    if (i == 0)
                    {
                        expected = TestHelper.Replace(expected, "Hello", 0);
                    }
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
    }
}
