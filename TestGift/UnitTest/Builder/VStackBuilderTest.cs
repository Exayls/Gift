using Gift.Builders;
using Gift.UI.Border;
using Gift.UI.Element;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
