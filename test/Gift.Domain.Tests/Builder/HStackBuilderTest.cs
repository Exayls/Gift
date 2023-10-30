using Gift.Domain.Builders;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
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
            IBuilder<HStack> builder = new HStackBuilder()
                .WithBound(bound)
                .WithBorder(border);
            HStack h = builder.Build();
            Assert.Equal(h.Border, border);
            Assert.Equal(h.Bound, bound);

        }
    }
}
