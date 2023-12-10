
using Gift.Domain.Builders;
using Gift.Domain.UIModel.Border;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class EqualityTest
    {


        public EqualityTest()
        {
        }


        [Fact]
        public void GiftUI_are_equals_when_2_are_default()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.Build();
			var element = new GiftUIBuilder()
				.Build();
			//Assert
            Assert.True(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_compared_to_label()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.Build();
			var element = new LabelBuilder()
				.Build();
			//Assert
            Assert.False(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_compared_to_vstack()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.Build();
			var element = new VStackBuilder()
				.Build();
			//Assert
            Assert.False(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_compared_different_size()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.WithBound(new(0,0))
				.Build();
			var element = new GiftUIBuilder()
				.WithBound(new(3,4))
				.Build();
			//Assert
            Assert.False(giftUIRef.Equals(element));
        }


        [Fact]
        public void GiftUI_are_not_equals_when_compared_different_border_thickness()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.WithBorder(new SimpleBorder(1, '*'))
				.Build();
			var element = new GiftUIBuilder()
				.WithBorder(new SimpleBorder(2, '*'))
				.Build();
			//Assert
            Assert.False(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_compared_different_border_style()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.WithBorder(new SimpleBorder(1, '*'))
				.Build();
			var element = new GiftUIBuilder()
				.WithBorder(new SimpleBorder(1, 'a'))
				.Build();
			//Assert
            Assert.False(giftUIRef.Equals(element));
        }
    }
}
