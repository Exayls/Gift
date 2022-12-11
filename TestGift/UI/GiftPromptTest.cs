
using Gift;
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
                var position = new Position(0, 0);
                var element = new Label("Hello", position);
                ui.setChild(element);

                ui.Render();

                Assert.Equal("Hello", output.ToString());
            }
        }
    }
}
