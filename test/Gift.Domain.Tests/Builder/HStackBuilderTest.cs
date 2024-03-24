using Gift.Domain.Builders.UIModel;
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
            Size bound = new Size(0, 0);
            HStackBuilder builder = new HStackBuilder()
                .WithBound(bound)
                .WithForegroundColor(Color.Blue)
                .WithBorder(border);
            HStack h = builder.Build();

            Assert.True(border.IsSimilarTo(h.Border));
            Assert.True(bound.Equals(h.Size));
            Assert.Equal(Color.Blue, h.FrontColor);
        }
    }
}
