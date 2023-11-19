
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

        [Fact]
        public void When_having_color_corresponding_to_define_color_should_return_color()
        {
            var colorAtt = "blue";
            var color = _mapper.ToColor(colorAtt);

            Assert.Equal(Color.Blue, color);
        }

    }
}
