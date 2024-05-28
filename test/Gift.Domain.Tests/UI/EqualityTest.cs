
using Gift.Domain.Builders.UIModel;
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
        public void VStack_are_equals_when_2_are_default()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .Build();
            var element = new VStackBuilder()
                .Build();
            //Assert
            Assert.True(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_to_label()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .Build();
            var element = new LabelBuilder()
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_to_vstack()
        {
            //Arrange
            var giftUIRef = new HStackBuilder()
                .Build();
            var element = new VStackBuilder()
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_different_size()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .WithBound(new(0, 0))
                .Build();
            var element = new VStackBuilder()
                .WithBound(new(3, 4))
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }


        [Fact]
        public void VStack_are_not_equals_when_compared_different_border_thickness()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .WithBorder(new SimpleBorder(1, '*'))
                .Build();
            var element = new VStackBuilder()
                .WithBorder(new SimpleBorder(2, '*'))
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_different_border_char()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .WithBorder(new SimpleBorder(1, '*'))
                .Build();
            var element = new VStackBuilder()
                .WithBorder(new SimpleBorder(1, 'a'))
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_different_backgroundColor()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .WithBackgroundColor(Color.Blue)
                .Build();
            var element = new VStackBuilder()
                .WithBackgroundColor(Color.Red)
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_not_equals_when_compared_different_foregroundColor()
        {
            //Arrange
            var giftUIRef = new VStackBuilder()
                .WithForegroundColor(Color.Blue)
                .Build();
            var element = new VStackBuilder()
                .WithForegroundColor(Color.Red)
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(element));
        }

        [Fact]
        public void VStack_are_equals_when_having_same_elements()
        {
            //Arrange
            var element1 = new VStackBuilder()
                .WithBound(new Size(0, 0))
                .Build();
            var giftUIRef = new VStackBuilder()
                .WithSelectableElement(element1)
                .Build();
            var element2 = new VStackBuilder()
                .WithBound(new Size(0, 0))
                .Build();
            var giftUIComp = new VStackBuilder()
                .WithSelectableElement(element2)
                .Build();
            //Assert
            Assert.True(giftUIRef.IsSimilarTo(giftUIComp));
        }

        [Fact]
        public void VStack_are_not_equals_when_having_different_elements()
        {
            //Arrange
            var element1 = new VStackBuilder()
                .WithBound(new Size(0, 0))
                .Build();
            var giftUIRef = new VStackBuilder()
                .WithSelectableElement(element1)
                .Build();

            var element2 = new VStackBuilder()
                .WithBound(new Size(0, 1))
                .Build();
            var giftUIComp = new VStackBuilder()
                .WithSelectableElement(element2)
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(giftUIComp));
        }

        [Fact]
        public void VStack_are_not_equals_when_having_different_containers()
        {
            //Arrange
            var element1 = new VStackBuilder()
                .WithBound(new Size(0, 0))
                .Build();
            var giftUIRef = new VStackBuilder()
                .IsSelectableContainer(true)
                .Build();

            var element2 = new VStackBuilder()
                .WithBound(new Size(1, 0))
                .Build();
            var giftUIComp = new VStackBuilder()
                .IsSelectableContainer(true)
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(giftUIComp));
        }

        [Fact]
        public void VStack_are_not_equals_when_having_different_number_of_containers()
        {
            //Arrange
            var element1 = new VStackBuilder()
                .WithBound(new Size(0, 0))
                .Build();
            var giftUIRef = new VStackBuilder()
                .IsSelectableContainer(true)
                .Build();

            var giftUIComp = new VStackBuilder()
                .Build();
            //Assert
            Assert.False(giftUIRef.IsSimilarTo(giftUIComp));
        }

    }
}
