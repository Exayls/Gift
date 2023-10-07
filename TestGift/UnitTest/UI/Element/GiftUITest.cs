using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System;
using Xunit;

namespace TestGift.UnitTest.UI.Element
{
    public class GiftUITest
    {
        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private GiftUI giftui;
        private Mock<Container> _containerMock;

        public GiftUITest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            _containerMock = new Mock<Container>();
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

            var container = new Mock<Container>();
            Assert.Throws<InvalidOperationException>(() => giftui.SelectedContainer = container.Object);
        }

        [Fact]
        public void SelectedContainer_should_define_selected_container_as_selected()
        {
            var container = new GiftUI();
            var uiElement = new Mock<UIElement>();
            //Act
			//
            giftui.SelectableContainers.Add(container);
            giftui.SelectedContainer = container;
            Assert.Equal(container, giftui.SelectedContainer);
			Assert.True(container.IsSelectedContainer);
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
            Container container = new GiftUI();
            giftui.SelectableContainers.Add(container);
            giftui.SelectedContainer = container;
            //Act
            giftui.NextContainer();
            //Assert
            Assert.Equal(container, giftui.SelectedContainer);
            Assert.True(container.IsSelectedContainer);
        }

        [Fact]
        public void NextContainer_should_change_container_if_selectedContainer_is_not_only_selectable()
        {
            //Arrange
            Mock<Container> container1 = new Mock<Container>();

            Mock<Container> container2 = new Mock<Container>();

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
            Mock<Container> container1 = new Mock<Container>();

            Mock<Container> container2 = new Mock<Container>();

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
			var giftui = GetGiftUI();
			var container = GetContainer();
            giftui.SelectableContainers.Add(container);

			var e1 = new GiftUI();
			var e2 = new GiftUI();
			container.AddSelectableChild(e1);
			container.AddSelectableChild(e2);
            giftui.SelectableContainers.Add(container);
            giftui.SelectedContainer = container;
            //Act
            giftui.NextElementInSelectedContainer();
            //Assert
			Assert.Equal(e2, container.SelectedElement);
        }

        private Container GetContainer()
        {
			return new GiftUI();
        }

        private GiftUI GetGiftUI()
        {
			return new GiftUI();
        }

        [Fact]
        public void PreviousElementInSelectedContainer_should_call_nextElement_if_selectedContainer_is_not_null()
        {
            //Arrange
			var giftui = new GiftUI();
			var container = new GiftUI();
			var e1 = new GiftUI();
			var e2 = new GiftUI();
			container.AddSelectableChild(e1);
			container.AddSelectableChild(e2);
			giftui.SelectableContainers.Add(container);
			giftui.SelectedContainer = container;
            //Act
            giftui.PreviousElementInSelectedContainer();
            //Assert
			Assert.Equal(e2, container.SelectedElement);
        }
    }
}
