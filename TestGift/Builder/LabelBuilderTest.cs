using Gift.Builders;
using Gift.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.Builder
{
    public class LabelBuilderTest
    {
        [Fact]
        public void BuilderNameTest()
        {

            LabelBuilder builder = new LabelBuilder();
            Label l = builder.Build();

            Assert.Equal("Hello",l.Text );
        }
        [Fact]
        public void BuilderPositionTest()
        {

            LabelBuilder builder = new LabelBuilder();
            Label l = builder.Build();

            Assert.Equal(0,l.Position.y );
            Assert.Equal(0,l.Position.x );
        }
    }
}
