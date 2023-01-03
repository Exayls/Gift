using Gift;
using Gift.UI;
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
                var ui = new GiftUI(new Renderer(writer));

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
    }
}