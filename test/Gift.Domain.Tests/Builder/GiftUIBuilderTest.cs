using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace TestGift.Builder
{
    public class GiftUIBuilderTest
    {
        private GiftUIBuilder builder;

        public GiftUIBuilderTest()
        {
            builder = new GiftUIBuilder();
        }

        [Fact]
        public void BuilderNameTest()
        {
            GiftUI g = builder.WithBound(new Size(20, 60)).Build();

            Assert.Equal(20, g.Bound.Height);
            Assert.Equal(60, g.Bound.Width);
        }
        [Fact]
        public void BuilderPositionTest()
        {
            GiftUI g = builder.WithBound(new Size(1, 23)).Build();

            Assert.Equal(1, g.Bound.Height);
            Assert.Equal(23, g.Bound.Width);
        }
    }
}
