using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.MetaData;
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

        [Fact]
        public void When_having_path_to_json_border_config_should_create_border()
        {
            var boundStr = "5,8";
            var bound = _mapper.ToBound(boundStr);
            Assert.Equal(5, bound.Height);
            Assert.Equal(8, bound.Width);
        }
    }
}
