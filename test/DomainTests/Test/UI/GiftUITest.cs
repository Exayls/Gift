using System.Text;
using Xunit;
using System.IO;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Conf;
using Gift.ApplicationService.Services;
using Gift.Displayer.Rendering;

namespace TestGift.UI
{
    public class GiftUITest
    {
        [Fact]
        public void CanRenderUserInterface()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));

                IScreenDisplay renderedText = new Renderer(new DefaultConfiguration()).GetRenderDisplay(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftLauncher.FILLINGCHAR, 60));
                for (int i = 1; i < 20; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftLauncher.FILLINGCHAR, 60));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.DisplayString.ToString());
            }
        }
        [Fact]
        public void CanRenderUserInterfaceDifferentSize()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(10, 15));

                IScreenDisplay renderedText = new Renderer(new DefaultConfiguration()).GetRenderDisplay(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftLauncher.FILLINGCHAR, 15));
                for (int i = 1; i < 10; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftLauncher.FILLINGCHAR, 15));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.DisplayString.ToString());
            }
        }
    }
}
