using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.Builder
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

            Assert.Equal(0, l.Disposition.Position.Y);
            Assert.Equal(0, l.Disposition.Position.X);
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
