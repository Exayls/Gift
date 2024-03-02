using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace TestGift.Builder
{
    public class BorderMapperTest
    {
        private readonly IBorderMapper _mapper;

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
            var expectedString =
             "┌─┐\n" +
             "│ │\n" +
             "└─┘";
            Assert.Equal(expectedString, border.GetDisplay(new Bound(3, 3), Color.Default, Color.Default, ' ').DisplayString.ToString());
        }

        [Fact]
        public void When_having_simple_should_create_simple_border()
        {
            var borderOption = "simple";
            var border = _mapper.ToBorder(borderOption);
            Assert.Equal(1, border.Thickness);
            var expectedString =
             "┌─┐\n" +
             "│ │\n" +
             "└─┘";
            Assert.Equal(expectedString, border.GetDisplay(new Bound(3, 3), Color.Default, Color.Default, ' ').DisplayString.ToString());
        }

        [Fact]
        public void When_having_heavy_should_create_heavy_border()
        {
            var borderOption = "heavy";
            var border = _mapper.ToBorder(borderOption);
            Assert.Equal(1, border.Thickness);
            var expectedString =
             "███\n" +
             "█ █\n" +
             "███";
            Assert.Equal(expectedString, border.GetDisplay(new Bound(3, 3), Color.Default, Color.Default, ' ').DisplayString.ToString());
        }
    }
}
