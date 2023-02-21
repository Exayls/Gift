using Gift;
using Gift.UI;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest
{
    public class RendererTest
    {
        private Mock<IGiftUI> _giftuiMock;
        private Mock<IScreenDisplay> _screenDisplayMock;
            private Renderer renderer;

        public RendererTest()
        {
            _giftuiMock = new Mock<IGiftUI>();
            _screenDisplayMock = new Mock<IScreenDisplay>();
            renderer = new Renderer();
        }

        [Fact]
        public void GetRenderedBuffer_should_return_empty_text_when_giftui_is_empty()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder());
            _screenDisplayMock.Setup(s => s.TotalBound).Returns(new Bound(0,0));
            _giftuiMock.Setup(m => m.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            _giftuiMock.Setup(m => m.GetGlobalPosition(It.IsAny<Context>())).Returns(new Position(0,0));
            _giftuiMock.Setup(m => m.Bound).Returns(new Bound(0,0));
            _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>());
            //act
            TextWriter actual = renderer.GetRenderedBuffer(_giftuiMock.Object);
            //assert
            Assert.Equal("", actual.ToString());
        }
        [Fact]
        public void GetRenderedBuffer_should_return_hello_text_when_giftui_has_label_hello()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder("hello"));
            _screenDisplayMock.Setup(s => s.TotalBound).Returns(new Bound(1,5));
            _giftuiMock.Setup(m => m.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            _giftuiMock.Setup(m => m.GetGlobalPosition(It.IsAny<Context>())).Returns(new Position(0,0));
            _giftuiMock.Setup(m => m.Bound).Returns(new Bound(1,5));
            _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>());
            //act
            TextWriter actual = renderer.GetRenderedBuffer(_giftuiMock.Object);
            //assert
            Assert.Equal("hello", actual.ToString());
        }
    }
}
