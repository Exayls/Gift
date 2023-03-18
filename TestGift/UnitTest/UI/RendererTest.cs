using Gift.UI;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest.UI
{
    public class RendererTest
    {
        private Mock<IGiftUI> _giftuiMock;
        private Mock<IScreenDisplay> _screenDisplayMock;
        private Mock<IUIElement> _labelMock;
        private Renderer renderer;

        public RendererTest()
        {
            _giftuiMock = new Mock<IGiftUI>();
            _screenDisplayMock = new Mock<IScreenDisplay>();
            _labelMock = new Mock<IUIElement>();
            renderer = new Renderer();
        }

        [Fact]
        public void GetRenderedBuffer_should_return_empty_text_when_giftui_is_empty()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder());
            _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
            //act
            TextWriter actual = renderer.GetRenderWriter(_giftuiMock.Object, _screenDisplayMock.Object);
            //assert
            Assert.Equal("", actual.ToString());
        }
        [Fact]
        public void GetRenderedBuffer_should_return_hello_text_when_giftui_has_label_hello()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder("hello"));
            _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
            //act
            TextWriter actual = renderer.GetRenderWriter(_giftuiMock.Object, _screenDisplayMock.Object);
            //assert
            Assert.Equal("hello", actual.ToString());
        }
        [Fact]
        public void GetRenderedBuffer_should_Call_GetDisplay_when_giftui_is_alone()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder("hello"));
            _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
            _giftuiMock.Setup(m => m.GetDisplay()).Returns(_screenDisplayMock.Object);
            //act
            TextWriter actual = renderer.GetRenderWriter(_giftuiMock.Object);
            //assert
            _giftuiMock.Verify(g => g.GetDisplay());
        }
        [Fact]
        public void GetRenderedBuffer_should_Call_GetDisplay_when_giftui_has_element()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder("hello"));
            _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>()
            {
                _labelMock.Object
            });
            _giftuiMock.Setup(m => m.GetDisplay()).Returns(_screenDisplayMock.Object);
            _giftuiMock.Setup(m => m.GetContextRenderable(It.IsAny<IRenderable>(), It.IsAny<Context>())).Returns(new Context(new(0, 0), new(0, 0)));
            //act
            TextWriter actual = renderer.GetRenderWriter(_giftuiMock.Object);
            //assert
            _labelMock.Verify(g => g.GetDisplay(It.IsAny<Bound>()));
        }
    }
}
