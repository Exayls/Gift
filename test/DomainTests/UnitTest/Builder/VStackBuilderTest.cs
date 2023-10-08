using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.src.Builders;
using Xunit;

namespace TestGift.Builder
{
    public class VStackBuilderTest
    {
        [Fact]
        public void BuilderNameTest()
        {

            VStackBuilder builder = new VStackBuilder();
            VStack v = builder.Build();
            Assert.True(v != null);

        }

        [Fact]
        public void BuilderWithParameter()
        {

            NoBorder border = new NoBorder();
            Bound bound = new Bound(0, 0);
            VStackBuilder builder = new VStackBuilder()
                .WithBorder(border)
                .WithBound(bound);
            VStack v = builder.Build();
            Assert.Equal(v.Border, border);
            Assert.Equal(v.Bound, bound);

        }
    }
}
