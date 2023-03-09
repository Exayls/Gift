using Gift.Builders;
using Gift.UI.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
