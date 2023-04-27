using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System.Text;

namespace TestGift.UnitTest.UI.Element
{
    public class ContainerTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<IUIElement> _uiElementMock1;
        private Mock<IUIElement> _uiElementMock2;
        private Mock<IUIElement> _uiElementMock3;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private VStack vstack;

        public ContainerTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<IUIElement>();
            _uiElementMock2 = new Mock<IUIElement>();
            _uiElementMock3 = new Mock<IUIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            vstack = new VStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
        }

        [Fact]
        public void When_NextElement_is_called_should_select_next_element()
        {
            //arrange
            vstack.SelectableElements.Add(_uiElementMock1.Object);
            vstack.SelectableElements.Add(_uiElementMock2.Object);
            vstack.SelectedElement = _uiElementMock1.Object;
            //act
            vstack.NextElement();
            //assert
            Assert.Equal(_uiElementMock2.Object, vstack.SelectedElement);
        }
        [Fact]
        public void When_NextElement_is_called_and_last_element_is_selected_should_select_first_element()
        {
            //arrange
            vstack.SelectableElements.Add(_uiElementMock1.Object);
            vstack.SelectableElements.Add(_uiElementMock2.Object);
            vstack.SelectedElement = _uiElementMock2.Object;
            //act
            vstack.NextElement();
            //assert
            Assert.Equal(_uiElementMock1.Object, vstack.SelectedElement);
        }

        [Fact]
        public void When_PreviousElement_is_called_should_select_next_element()
        {
            //arrange
            vstack.SelectableElements.Add(_uiElementMock1.Object);
            vstack.SelectableElements.Add(_uiElementMock2.Object);
            vstack.SelectableElements.Add(_uiElementMock3.Object);
            vstack.SelectedElement = _uiElementMock3.Object;
            //act
            vstack.PreviousElement();
            //assert
            Assert.Equal(_uiElementMock2.Object, vstack.SelectedElement);
        }

        [Fact]
        public void When_PreviousElement_is_called_and_first_element_is_selected_should_select_last_element()
        {
            //arrange
            vstack.SelectableElements.Add(_uiElementMock1.Object);
            vstack.SelectableElements.Add(_uiElementMock2.Object);
            vstack.SelectableElements.Add(_uiElementMock3.Object);
            vstack.SelectedElement = _uiElementMock1.Object;
            //act
            vstack.PreviousElement();
            //assert
            Assert.Equal(_uiElementMock3.Object, vstack.SelectedElement);
        }
    }
}
