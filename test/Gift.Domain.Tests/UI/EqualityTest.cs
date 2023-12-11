
using Gift.Domain.Builders;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
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
                .WithBound(new(0, 0))
                .Build();
            var element = new GiftUIBuilder()
                .WithBound(new(3, 4))
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
        public void GiftUI_are_not_equals_when_compared_different_border_char()
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

        [Fact]
        public void GiftUI_are_not_equals_when_compared_different_backgroundColor()
        {
            //Arrange
            var giftUIRef = new GiftUIBuilder()
                .WithBackgroundColor(Color.Blue)
                .Build();
            var element = new GiftUIBuilder()
                .WithBackgroundColor(Color.Red)
                .Build();
            //Assert
            Assert.False(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_compared_different_foregroundColor()
        {
            //Arrange
            var giftUIRef = new GiftUIBuilder()
                .WithForegroundColor(Color.Blue)
                .Build();
            var element = new GiftUIBuilder()
                .WithForegroundColor(Color.Red)
                .Build();
            //Assert
            Assert.False(giftUIRef.Equals(element));
        }

        [Fact]
        public void GiftUI_are_equals_when_having_same_elements()
        {
            //Arrange
            var element1 = new GiftUIBuilder()
				.WithBound(new Bound(0,0))
				.Build();
            var giftUIRef = new GiftUIBuilder()
                .WithSelectableElement(element1)
                .Build();
            var element2 = new GiftUIBuilder()
				.WithBound(new Bound(0,0))
				.Build();
            var giftUIComp = new GiftUIBuilder()
                .WithSelectableElement(element2)
                .Build();
            //Assert
            Assert.True(giftUIRef.Equals(giftUIComp));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_having_different_elements()
        {
            //Arrange
            var element1 = new GiftUIBuilder()
				.WithBound(new Bound(0,0))
				.Build();
            var giftUIRef = new GiftUIBuilder()
                .WithSelectableElement(element1)
                .Build();

            var element2 = new GiftUIBuilder()
				.WithBound(new Bound(0,1))
				.Build();
            var giftUIComp = new GiftUIBuilder()
                .WithSelectableElement(element2)
                .Build();
            //Assert
            Assert.False(giftUIRef.Equals(giftUIComp));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_having_different_containers()
        {
            //Arrange
            var element1 = new VStackBuilder()
				.WithBound(new Bound(0,0))
				.Build();
            var giftUIRef = new GiftUIBuilder()
                .WithSelectableContainer(element1)
                .Build();

            var element2 = new VStackBuilder()
				.WithBound(new Bound(1,0))
				.Build();
            var giftUIComp = new GiftUIBuilder()
                .WithSelectableContainer(element2)
                .Build();
            //Assert
            Assert.False(giftUIRef.Equals(giftUIComp));
        }

        [Fact]
        public void GiftUI_are_not_equals_when_having_different_number_of_containers()
        {
            //Arrange
            var element1 = new VStackBuilder()
				.WithBound(new Bound(0,0))
				.Build();
            var giftUIRef = new GiftUIBuilder()
                .WithSelectableContainer(element1)
                .Build();

            var giftUIComp = new GiftUIBuilder()
                .Build();
            //Assert
            Assert.False(giftUIRef.Equals(giftUIComp));
        }

    }
}
