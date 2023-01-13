using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.Builder
{
    public class GiftUIBuilderTest
    {
        [Fact]
        public void BuilderNameTest()
        {

            GiftUIBuilder builder = new GiftUIBuilder();
            GiftUI g = builder.Build();

            Assert.Equal(20,g.Bound.Height);
            Assert.Equal(60,g.Bound.Width);
        }
        [Fact]
        public void BuilderPositionTest()
        {

            GiftUIBuilder builder = new GiftUIBuilder();
            GiftUI g = builder.WithBound(new Bound(1,23)).Build();

            Assert.Equal(1,g.Bound.Height);
            Assert.Equal(23,g.Bound.Width);
        }
    }
}
