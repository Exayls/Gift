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
                var ui = new GiftUI(new Renderer(writer),new Bound(20,60));

                ui.Render();
                var expectedBuilder = new StringBuilder();
                for (int i = 0; i < 20; i++)
                {
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 60));
                    expectedBuilder.Append('\n');
                }

                Assert.Equal(expectedBuilder.ToString(), output.ToString());
            }
        }
        [Fact]
        public void CanDisplayUserInterfaceDifferentSize()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Renderer(writer),new Bound(10,15));

                ui.Render();
                var expectedBuilder = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 15));
                    expectedBuilder.Append('\n');
                }

                Assert.Equal(expectedBuilder.ToString(), output.ToString());
            }
        }
    }
}