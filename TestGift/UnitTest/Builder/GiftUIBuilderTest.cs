using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
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
            GiftUI g = builder.Build();

            Assert.Equal(20, g.Bound.Height);
            Assert.Equal(60, g.Bound.Width);
        }
        [Fact]
        public void BuilderPositionTest()
        {
            GiftUI g = builder.WithBound(new Bound(1, 23)).Build();

            Assert.Equal(1, g.Bound.Height);
            Assert.Equal(23, g.Bound.Width);
        }
    }
}
