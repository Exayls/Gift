using System.Text;
using Xunit;
using System.IO;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Conf;
using Gift.ApplicationService.Services;
using Gift.Displayer.Rendering;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Element;
using Gift.Repository.Repository;
using Gift.Domain.UIModel.Services;

namespace Gift.Displayer.Tests.Integration
{
    public class GiftUITest
    {

        private static Renderer GetRenderer(IRepository repository)
        {
            return new Renderer(new DefaultConfiguration(), new ColorResolver(repository), new TrueElementSizeCalculator(repository));
        }

        [Fact]
        public void CanRenderUserInterface()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var repo = new InMemoryRepository();
                var ui = GetGiftUI(new Size(20, 60));
                repo.SaveRoot(ui);
                IScreenDisplay renderedText =
                    GetRenderer(repo).GetRenderDisplay(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, 60));
                for (int i = 1; i < 20; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, 60));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.DisplayString.ToString());
            }
        }

        private static VStack GetGiftUI(Size bound)
        {
            return new VStackBuilder().WithBound(bound).Build();
        }

        [Fact]
        public void CanRenderUserInterfaceDifferentSize()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = GetGiftUI(new Size(10, 15));

                var repo = new InMemoryRepository();
                repo.SaveRoot(ui);
                IScreenDisplay renderedText =
                    GetRenderer(repo).GetRenderDisplay(ui);
                var expectedBuilder = new StringBuilder();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, 15));
                for (int i = 1; i < 10; i++)
                {
                    expectedBuilder.Append('\n');
                    expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, 15));
                }

                Assert.Equal(expectedBuilder.ToString(), renderedText.DisplayString.ToString());
            }
        }
    }
}
