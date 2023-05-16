using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest.UI.Element
{
    public class GiftUITest
    {
        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private GiftUI giftui;

        public GiftUITest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
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
    }
}
