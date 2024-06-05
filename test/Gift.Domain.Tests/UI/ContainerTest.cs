using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Moq;
using TestGift.Mocks;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class ContainerTest
    {

        private Mock<IBorder> _borderMock;
        private VStack vstack;

        public ContainerTest()
        {
            _borderMock = new Mock<IBorder>();
            vstack = new VStackBuilder().WithBorder(_borderMock.Object).Build();
        }

        [Fact]
        public void When_NextElement_is_called_should_select_next_element()
        {
            //arrange
            UIElement element1 = CreateUIElement();
            vstack.AddSelectableChild(element1);

            UIElement element2 = CreateUIElement();
            vstack.AddSelectableChild(element2);

            //act
            vstack.NextElement();
            //assert
            Assert.Equal(element2, vstack.SelectedElement);
        }

        private UIElement CreateUIElement()
        {
            return new MockUIElement();
        }


        [Fact]
        public void When_NextElement_is_called_and_last_element_is_selected_should_select_first_element()
        {
            //arrange
            UIElement element1 = CreateUIElement();
            vstack.AddSelectableChild(element1);
            UIElement element2 = CreateUIElement();
            vstack.AddSelectableChild(element2);
            vstack.SelectedElement = element2;
            //act
            vstack.NextElement();
            //assert
            Assert.Equal(element1, vstack.SelectedElement);
        }

        [Fact]
        public void When_PreviousElement_is_called_should_select_next_element()
        {
            //arrange
            UIElement element1 = CreateUIElement();
            vstack.AddSelectableChild(element1);
            UIElement element2 = CreateUIElement();
            vstack.AddSelectableChild(element2);
            UIElement element3 = CreateUIElement();
            vstack.AddSelectableChild(element3);
            vstack.SelectedElement = element3;
            //act
            vstack.PreviousElement();
            //assert
            Assert.Equal(element2, vstack.SelectedElement);
        }

        [Fact]
        public void When_PreviousElement_is_called_and_first_element_is_selected_should_select_last_element()
        {
            //arrange
            UIElement element1 = CreateUIElement();
            vstack.AddSelectableChild(element1);
            UIElement element2 = CreateUIElement();
            vstack.AddSelectableChild(element2);
            UIElement element3 = CreateUIElement();
            vstack.AddSelectableChild(element3);
            vstack.SelectedElement = element1;
            //act
            vstack.PreviousElement();
            //assert
            Assert.Equal(element3, vstack.SelectedElement);
        }
    }
}
