using Gift.Displayer.Rendering;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;
using Moq;

namespace TestGift.UnitTest.UI
{
    public class RendererTest
    {
        private Mock<IConfiguration> _confMock;
        private Mock<UIElement> _labelMock;
        private MockRepository _mockFactory;
        private Renderer renderer;

        public RendererTest()
        {
            _confMock = new Mock<IConfiguration>();
            _labelMock = new Mock<UIElement>();
            _mockFactory = new MockRepository(MockBehavior.Default);
            renderer = new Renderer(_confMock.Object);
        }

        //[Fact]
        //public void GetRenderedBuffer_should_return_empty_text_when_giftui_is_empty()
        //{
        //    //arrange
        //    var screenDisplay = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder())
        //        .First();
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>());
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
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>());
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
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>());
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
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>()
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
        //    UIElement element1 = _mockFactory.Of<UIElement>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayLabel1)
        //        .First();
        //    //label2
        //    IScreenDisplay screenDisplayLabel2 = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "test"))
        //        .First();
        //    UIElement element2 = _mockFactory.Of<UIElement>()
        //        .Where(s => s.GetDisplay(It.IsAny<Bound>()) == screenDisplayLabel2)
        //        .First();
        //    //label3
        //    IScreenDisplay screenDisplayLabel3 = _mockFactory.Of<IScreenDisplay>()
        //        .Where(s => s.DisplayString == new StringBuilder(
        //            "testToLongString"))
        //        .First();
        //    UIElement element3 = _mockFactory.Of<UIElement>()
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
        //        .Where(s => s.Childs == new Collection<UIElement>()
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
        //    _giftuiMock.Setup(m => m.Childs).Returns(new List<UIElement>()
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
