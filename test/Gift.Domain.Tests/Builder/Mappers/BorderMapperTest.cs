using Gift.Domain.Builders.Mappers;
using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.Builder.Mappers
{
    public class BorderMapperTest
    {
        private readonly BorderMapper _mapper;

        public BorderMapperTest()
        {
            _mapper = new BorderMapper();
        }

        [Fact]
        public void When_having_path_to_json_border_config_should_create_border()
        {
            var borderFile = "ressources/simple_border.json";
            var border = _mapper.ToBorder(borderFile);
            Assert.Equal(1, border.Thickness);
            var expectedString = "┌─┐\n" + "│ │\n" + "└─┘";
            var screen = new ScreenDisplayBuilder()
                             .WithFrontColor(Color.Default)
                             .WithBackColor(Color.Default)
                             .WithChar(' ')
                             .WithBound(new Size(3, 3));
            Assert.Equal(expectedString, border.GetDisplay(screen).DisplayString.ToString());
        }

        private static IScreenDisplay GetDisplay(Size bound, Color frcol, Color bckcol, char ch, IBorder border)
        {

            var screen =
                new ScreenDisplayBuilder().WithFrontColor(frcol).WithBackColor(bckcol).WithChar(ch).WithBound(bound);
            return border.GetDisplay(screen);
        }

        [Fact]
        public void When_having_simple_should_create_simple_border()
        {
            var borderOption = "simple";
            var border = _mapper.ToBorder(borderOption);
            Assert.Equal(1, border.Thickness);
            var expectedString = "┌─┐\n" + "│ │\n" + "└─┘";
            Assert.Equal(
                expectedString,
                GetDisplay(new Size(3, 3), Color.Default, Color.Default, ' ', border).DisplayString.ToString());
        }

        [Fact]
        public void When_having_heavy_should_create_heavy_border()
        {
            var borderOption = "heavy";
            var border = _mapper.ToBorder(borderOption);
            Assert.Equal(1, border.Thickness);
            var expectedString = "███\n" + "█ █\n" + "███";
            Assert.Equal(
                expectedString,
                GetDisplay(new Size(3, 3), Color.Default, Color.Default, ' ', border).DisplayString.ToString());
        }
    }
}
