using Gift.UI;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest.UI
{
    public class RendererTest
    {
        private Mock<IGiftUI> _giftuiMock;
        private Mock<IUIElement> _labelMock;
        private MockRepository _mockFactory;
        private Renderer renderer;

        public RendererTest()
        {
            _giftuiMock = new Mock<IGiftUI>();
            _labelMock = new Mock<IUIElement>();
            _mockFactory = new MockRepository(MockBehavior.Default);
            renderer = new Renderer();
        }

        //[Fact]
        //public void GetRenderedBuffer_should_return_empty_text_when_giftui_is_empty()
        //{
        //    //arrange
        //    var screenDisplay = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder())
        //        .First();
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
        //    _giftuiMock.Setup(m => m.GetDisplay()).Returns(screenDisplay);
        //    //act
        //    IScreenDisplay actual = renderer.GetRenderDisplay(_giftuiMock.Object);
        //    //assert
        //    Assert.Equal("", actual.DisplayString.ToString());
        //}

        //[Fact]
        //public void GetRenderedBuffer_should_return_hello_text_when_giftui_has_label_hello()
        //{
        //    //arrange
        //    var screenDisplay = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder("hello"))
        //        .First();
        //    //screenDisplay.Setup(s => s.DisplayString).Returns(new StringBuilder("hello"));
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
        //    _giftuiMock.Setup(m => m.GetDisplay()).Returns(screenDisplay);
        //    //act
        //    IScreenDisplay actual = renderer.GetRenderDisplay(_giftuiMock.Object);
        //    //assert
        //    Assert.Equal("hello", actual.DisplayString.ToString());
        //}

        //[Fact]
        //public void GetRenderedBuffer_should_Call_GetDisplay_when_giftui_is_alone()
        //{
        //    //arrange
        //    var screenDisplay = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder("hello"))
        //        .First();
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>());
        //    _giftuiMock.Setup(m => m.GetDisplay()).Returns(screenDisplay);
        //    //act
        //    IScreenDisplay actual = renderer.GetRenderDisplay(_giftuiMock.Object);
        //    //assert
        //    _giftuiMock.Verify(g => g.GetDisplay());
        //}

        //[Fact]
        //public void GetRenderedBuffer_should_Call_GetDisplay_when_giftui_has_element()
        //{
        //    //arrange
        //    var screenDisplay = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder("hello"))
        //        .First();
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>()
        //    {
        //        _labelMock.Object
        //    });
        //    _giftuiMock.Setup(m => m.GetDisplay(It.IsAny<Bound>())).Returns(screenDisplay);
        //    _giftuiMock.Setup(m => m.GetDisplay()).Returns(screenDisplay);
        //    _giftuiMock.Setup(m => m.GetContextRenderable(It.IsAny<IRenderable>(), It.IsAny<Context>())).Returns(new Context(new(0, 0), new(0, 0)));
        //    //act
        //    IScreenDisplay actual = renderer.GetRenderDisplay(_giftuiMock.Object);
        //    //assert
        //    _labelMock.Verify(g => g.GetDisplay(It.IsAny<Bound>()));
        //}

        //[Fact]
        //public void GetRenderedBuffer_should_return_correct_vstack()
        //{
        //    //arrange
        //    //label1
        //    IScreenDisplay screenDisplayLabel1 = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "hello"))
        //        .First();
        //    IUIElement element1 = _mockFactory.Of<IUIElement>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayLabel1)
        //        .First();
        //    //label2
        //    IScreenDisplay screenDisplayLabel2 = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "test"))
        //        .First();
        //    IUIElement element2 = _mockFactory.Of<IUIElement>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayLabel2)
        //        .First();
        //    //label3
        //    IScreenDisplay screenDisplayLabel3 = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "testToLongString"))
        //        .First();
        //    IUIElement element3 = _mockFactory.Of<IUIElement>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayLabel3)
        //        .First();


        //    IScreenDisplay screenDisplayVstack = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "+++++\n" +
        //            "+   +\n" +
        //            "+   +\n" +
        //            "+   +\n" +
        //            "+++++"))
        //        .First();
        //    IContainer vstack = _mockFactory.Of<IContainer>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayVstack)
        //        .Where(s => s.Childs == new Collection<IUIElement>()
        //        {
        //            element1,
        //            element2,
        //            element3
        //        }
        //        )
        //        .First();

        //    IScreenDisplay screenDisplayGift = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "     \n" +
        //            "     \n" +
        //            "     \n" +
        //            "     \n" +
        //            "     "))
        //        .First();
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<IUIElement>()
        //    {
        //        vstack
        //    });
        //    _giftuiMock.Setup(m => m.GetDisplay(It.IsAny<Bound>())).Returns(screenDisplayGift);
        //    _giftuiMock.Setup(m => m.GetDisplay()).Returns(screenDisplayGift);
        //    _giftuiMock.Setup(m => m.GetContextRenderable(It.IsAny<IRenderable>(), It.IsAny<Context>())).Returns(new Context(new(0, 0), new(0, 0)));
        //    //act
        //    TextWriter actual = renderer.GetRenderedBuffer(_giftuiMock.Object);
        //    //assert
        //}
    }
}
