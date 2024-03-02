using Gift.Domain.Builders.Mappers;
using Xunit;

namespace TestGift.Builder
{
    public class BoundMapperTest
    {
        private readonly IBoundMapper _mapper;

        public BoundMapperTest()
        {
            _mapper = new BoundMapper();
        }

        [Theory]
        [InlineData("5,8", 5, 8)]
        [InlineData("9;14", 9, 14)]
        [InlineData("1,3", 1, 3)]
        public void When_having_str_bound_should_return_bound_with_height_width(string boundStr, int height, int width)
        {
            var bound = _mapper.ToBound(boundStr);
            Assert.Equal(height, bound.Height);
            Assert.Equal(width, bound.Width);
        }
    }
}
