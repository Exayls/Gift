using Gift.Domain.UIModel.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using TestGift.Mocks;
using Xunit;

namespace TestGift.UnitTest.UI.Element
{
    public class ContainerTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<UIElement> _uiElementMock1;
        private Mock<UIElement> _uiElementMock2;
        private Mock<UIElement> _uiElementMock3;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private VStack vstack;

        public ContainerTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<UIElement>();
            _uiElementMock2 = new Mock<UIElement>();
            _uiElementMock3 = new Mock<UIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            vstack = new VStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
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
