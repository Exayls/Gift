using Gift;
using System.Text;

namespace TestGift.View
{
    public class GiftUITest
    {
        [Fact]
        public void CanDisplayUserInterface()
        {
            // Set up the test by creating a new instance of the TerminalUI class
            var ui = new GiftUI(new Renderer());

            // Use a StringBuilder to capture the output from the user interface
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                Console.SetOut(writer);

                ui.Render();

                Assert.Equal("Hello", output.ToString());
            }
        }
    }
}