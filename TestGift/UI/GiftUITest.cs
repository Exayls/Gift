using Gift;
using Gift.UI;
using Gift.UI.MetaData;
using System.Text;

namespace TestGift.UI
{
    public class GiftUITest
    {
        [Fact]
        public void CanDisplayUserInterface()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));

                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 60));
                for (int i = 1; i < 20; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 60));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.ToString());
            }
        }
        [Fact]
        public void CanDisplayUserInterfaceDifferentSize()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(10, 15));

                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 15));
                for (int i = 1; i < 10; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 15));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.ToString());
            }
        }
    }
}