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
            Label l = builder.build();

            Assert.Equal("Hello",l.Text );
        }
    }
}
