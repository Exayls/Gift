using Gift.Builders;
using Gift.UI.Element;
using Gift.UI.MetaData;
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

            Assert.Equal("Hello", l.Text);
        }

        [Fact]
        public void BuilderPositionTest()
        {

            LabelBuilder builder = new LabelBuilder();
            Label l = builder.Build();

            Assert.Equal(0, l.Disposition.Position.y);
            Assert.Equal(0, l.Disposition.Position.x);
        }

        [Fact]
        public void BuilderBackgroundTest()
        {

            LabelBuilder builder = new LabelBuilder()
                .WithBackgroundColor(Color.Green)
                .WithForegroundColor(Color.Red);
            Label l = builder.Build();

            Assert.Equal(Color.Green, l.BackColor);
            Assert.Equal(Color.Red, l.FrontColor);
        }
    }
}
