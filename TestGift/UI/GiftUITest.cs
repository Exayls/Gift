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

                Assert.Equal("", output.ToString());
            }
        }
    }
}