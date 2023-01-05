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
        public void TestLabelOutputFull()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer),new Bound(20,60));
                var vstack = new VStackBuilder().build();
                ui.setChild(vstack);
                ui.Render();

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = output.ToString().Split('\n');
                for (int i = 0; i < ui.Bound.Height; i++)
                {
                    expectedBuilder.Clear();
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                    expected = expectedBuilder.ToString();
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
    }
}
