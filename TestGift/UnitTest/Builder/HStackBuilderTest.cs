using Gift.Builders;
using Gift.UI.Border;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Xunit;

namespace TestGift.Builder
{
    public class HStackBuilderTest
    {
        [Fact]
        public void BuilderNameTest()
        {

            HStackBuilder builder = new HStackBuilder();
            HStack h = builder.Build();
            Assert.True(h != null);

        }

        [Fact]
        public void BuilderWithParameter()
        {

            NoBorder border = new NoBorder();
            Bound bound = new Bound(0, 0);
            HStackBuilder builder = new HStackBuilder()
                .WithBorder(border)
                .WithBound(bound);
            HStack h = builder.Build();
            Assert.Equal(h.Border, border);
            Assert.Equal(h.Bound, bound);

        }
    }
}
