
using Gift.Domain.Builders;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace TestGift.Builder
{
    public class ColorMapperTest
    {
        private readonly IColorMapper _mapper;

        public ColorMapperTest()
        {
            _mapper = new ColorMapper();
        }

        [Theory]
		[InlineData("blue", Color.Blue)]
		[InlineData("red", Color.Red)]
		[InlineData("GREEN", Color.Green)]
        public void When_having_color_corresponding_to_define_color_should_return_color(string attribute, Color color)
        {
            var actualColor = _mapper.ToColor(attribute);

            Assert.Equal(color, actualColor);
        }

    }
}
