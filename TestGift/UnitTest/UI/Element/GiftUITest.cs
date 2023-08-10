using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestGift.UnitTest.UI.Element
{
    public class GiftUITest
    {
        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private GiftUI giftui;
        private Mock<IContainer> _containerMock;

        public GiftUITest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            _containerMock = new Mock<IContainer>();
            giftui = new GiftUI(new Bound(5, 5), _borderMock.Object);
        }

        [Fact]
        public void Height_and_Width_should_return_Bounds()
        {
            //assert
            Assert.Equal(5, giftui.Height);
            Assert.Equal(5, giftui.Width);
        }

        [Fact]
        public void SelectedContainer_should_throw_when_nulll_value()
        {
            Assert.Throws<ArgumentNullException>(() => giftui.SelectedContainer = null);
        }

        [Fact]
        public void SelectedContainer_should_throw_when_setting_container_outside_of_selectable()
        {

            var container = new Mock<IContainer>();
            Assert.Throws<InvalidOperationException>(() => giftui.SelectedContainer = container.Object);
        }

        [Fact]
        public void SelectedContainer_should_define_selected_container_as_selected()
        {
            var container = new Mock<IContainer>();
            var uiElement = new Mock<IUIElement>();
            container.Setup(c => c.SelectableElements).Returns(new List<IUIElement>() { uiElement.Object });
            //Act
            giftui.SelectableContainers.Add(container.Object);
            giftui.SelectedContainer = container.Object;
            Assert.Equal(container.Object, giftui.SelectedContainer);
            container.VerifySet(c => c.IsSelectedContainer = true);
        }

        [Fact]
        public void IsFixed_should_return_false()
        {
            Assert.False(giftui.IsFixed());
        }

        [Fact]
        public void NextContainer_should_do_nothing_if_selectedContainer_null()
        {
            //Act
            giftui.NextContainer();
            //Assert
            Assert.Null(giftui.SelectedContainer);
        }

        [Fact]
        public void NextContainer_should_not_change_container_if_selectedContainer_is_only_selectable()
        {
            //Arrange
            Mock<IContainer> container = new Mock<IContainer>();
            container.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());
            giftui.SelectableContainers.Add(container.Object);
            giftui.SelectedContainer = container.Object;
            //Act
            giftui.NextContainer();
            //Assert
            Assert.Equal(container.Object, giftui.SelectedContainer);
        }

        [Fact]
        public void NextContainer_should_change_container_if_selectedContainer_is_not_only_selectable()
        {
            //Arrange
            Mock<IContainer> container1 = new Mock<IContainer>();
            container1.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());

            Mock<IContainer> container2 = new Mock<IContainer>();
            container2.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());

            giftui.SelectableContainers.Add(container1.Object);
            giftui.SelectableContainers.Add(container2.Object);

            giftui.SelectedContainer = container1.Object;
            //Act
            giftui.NextContainer();
            //Assert
            Assert.Equal(container2.Object, giftui.SelectedContainer);
        }

        [Fact]
        public void PreviousContainer_should_change_container_if_selectedContainer_is_not_only_selectable()
        {
            //Arrange
            Mock<IContainer> container1 = new Mock<IContainer>();
            container1.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());

            Mock<IContainer> container2 = new Mock<IContainer>();
            container2.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());

            giftui.SelectableContainers.Add(container1.Object);
            giftui.SelectableContainers.Add(container2.Object);

            giftui.SelectedContainer = container1.Object;
            //Act
            giftui.PreviousContainer();
            //Assert
            Assert.Equal(container2.Object, giftui.SelectedContainer);
        }

        [Fact]
        public void NextElementInSelectedContainer_should_not_change_element_in_selected_container_if_selectedContainer_is_null()
        {
            //Act
            giftui.NextElementInSelectedContainer();
            Assert.True(true);
            
        }

        [Fact]
        public void NextElementInSelectedContainer_should_call_nextElement_if_selectedContainer_is_not_null()
        {
            //Arrange
            _containerMock.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());
            giftui.SelectableContainers.Add(_containerMock.Object);

            giftui.SelectedContainer = _containerMock.Object;
            //Act
            giftui.NextElementInSelectedContainer();
            //Assert
            _containerMock.Verify(c => c.NextElement());
        }

        [Fact]
        public void PreviousElementInSelectedContainer_should_call_nextElement_if_selectedContainer_is_not_null()
        {
            //Arrange
            _containerMock.Setup(c => c.SelectableElements).Returns(new List<IUIElement>());
            giftui.SelectableContainers.Add(_containerMock.Object);

            giftui.SelectedContainer = _containerMock.Object;
            //Act
            giftui.PreviousElementInSelectedContainer();
            //Assert
            _containerMock.Verify(c => c.PreviousElement());
        }
    }
}
