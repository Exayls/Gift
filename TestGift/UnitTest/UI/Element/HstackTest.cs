
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System.Text;

namespace TestGift.UnitTest.UI.Element
{
    public class HStackTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<IUIElement> _uiElementMock1;
        private Mock<IUIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private HStack HStack;

        public HStackTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<IUIElement>();
            _uiElementMock2 = new Mock<IUIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
        }
        //GetDisplay tests
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whith_no_border()
        {
            //arrange
            _screenDisplayMock2.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("    \n").Append("    "));
            _borderMock.Setup(b => b.Thickness).Returns(0);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplayWithBorder(new(2, 4), '*');
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 4 && b.Height == 2), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 0 && p.x == 0)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            //arrange
            _screenDisplayMock2.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("----\n").Append("-  -\n").Append("----"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplayWithBorder(new Bound(3, 4), '*');
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 2 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 1 && p.x == 1)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("____\n").Append("_ii_\n").Append("____"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplayWithBorder(new Bound(3, 4), '*');
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 2 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 1 && p.x == 1)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("iiii\n").Append("illi\n").Append("iiii"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(3, 4));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 2 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 1 && p.x == 1)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("-----\n").Append("-   -\n").Append("-   -\n").Append("-   -\n").Append("-----"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(5, 5));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 3 && b.Height == 3), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 1 && p.x == 1)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(
                new StringBuilder().Append("------\n")
                                   .Append("-    -\n")
                                   .Append("------"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(3, 6));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 4 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 1 && p.x == 1)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(
                new StringBuilder().Append("-----\n")
                                   .Append("-----\n")
                                   .Append("-- --\n")
                                   .Append("-----\n")
                                   .Append("-----"));
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(5, 5));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 1 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 2 && p.x == 2)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(
                new StringBuilder().Append("-------\n").
                                    Append("-------\n").
                                    Append("--   --\n").
                                    Append("--   --\n").
                                    Append("-------\n").
                                    Append("-------"));
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(6, 7));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 3 && b.Height == 2), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 2 && p.x == 2)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(
                new StringBuilder().Append("-------\n").
                                    Append("-------\n").
                                    Append("-------\n").
                                    Append("--- ---\n").
                                    Append("-------\n").
                                    Append("-------\n").
                                    Append("-------"));
            _borderMock.Setup(b => b.Thickness).Returns(3);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplay(new(7, 7));
            //assert
            _ScreenDisplayFactoryMock.Verify(s => s.Create(It.Is<Bound>(b => b.Width == 1 && b.Height == 1), It.IsAny<Color>(), It.IsAny<Color>(), '*'));
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 3 && p.x == 3)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness4()
        {
            //arrange
            _screenDisplayMock1.Setup(s => s.DisplayString).Returns(
                new StringBuilder().Append("-------\n").
                                    Append("-------\n").
                                    Append("-------\n").
                                    Append("--- ---\n").
                                    Append("-------\n").
                                    Append("-------\n").
                                    Append("-------"));
            _borderMock.Setup(b => b.Thickness).Returns(3);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            HStack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = HStack.GetDisplayWithBorder(new(7, 7), 'b');
            //assert
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 3 && p.x == 3)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }
        //GetContext tests
        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_HStack_has_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_1_position_when_HStack_has_border_thickness1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(1, context.Position.y);
            Assert.Equal(1, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_2_2_position_when_HStack_has_border_thickness2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(2, context.Position.y);
            Assert.Equal(2, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_3_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock2.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock2.Setup(u => u.Width).Returns(1);
            HStack.Border = _borderMock.Object;
            HStack.AddChild(_uiElementMock2.Object);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(2, context.Position.y);
            Assert.Equal(3, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_4_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock2.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock2.Setup(u => u.Width).Returns(2);
            HStack.Border = _borderMock.Object;
            HStack.AddChild(_uiElementMock2.Object);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(2, context.Position.y);
            Assert.Equal(4, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_1_bound_when_HStack_has_child_with_Width_of_1_and_width_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock1.Setup(u => u.Width).Returns(1);
            _uiElementMock1.Setup(u => u.Height).Returns(1);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Width);
            Assert.Equal(1, context.Bounds.Height);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_5_bound_when_HStack_has_child_with_Width_of_1_and_width_5()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock1.Setup(u => u.Width).Returns(1);
            _uiElementMock1.Setup(u => u.Height).Returns(5);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Width);
            Assert.Equal(5, context.Bounds.Height);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_3_bound_when_HStack_has_child_with_Width_of_1_and_width_3()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock1.Setup(u => u.Width).Returns(1);
            _uiElementMock1.Setup(u => u.Height).Returns(3);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Width);
            Assert.Equal(3, context.Bounds.Height);
        }
        [Fact]
        public void GetContext_should_return_context_with_2_1_bound_when_HStack_has_child_with_Width_of_2_and_width_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock1.Setup(u => u.Width).Returns(2);
            _uiElementMock1.Setup(u => u.Height).Returns(1);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(2, context.Bounds.Width);
            Assert.Equal(1, context.Bounds.Height);
        }
        [Fact]
        public void GetContext_should_return_context_with_3_1_bound_when_HStack_has_child_with_Width_of_3_and_width_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            _uiElementMock1.Setup(u => u.IsFixed()).Returns(false);
            _uiElementMock1.Setup(u => u.Width).Returns(3);
            _uiElementMock1.Setup(u => u.Height).Returns(1);
            HStack.AddChild(_uiElementMock1.Object);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRenderable(_uiElementMock1.Object, contextRenderable);
            //assert
            Assert.Equal(3, context.Bounds.Width);
            Assert.Equal(1, context.Bounds.Height);
        }

        //Height/Width Tests
        [Fact]
        public void Width_should_be_1_when_1_element_Width_1_in_it_with_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(1, HStack.Width);
        }
        [Fact]
        public void Width_should_be_4_when_2_element_Width_2_in_it_with_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(2);
            _uiElementMock2.Setup(ui => ui.Width).Returns(2);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            HStack.AddChild(_uiElementMock2.Object);
            //assert
            Assert.Equal(4, HStack.Width);
        }
        [Fact]
        public void Width_should_be_5_when_2_element_Width_total_is_5_in_it_with_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(2);
            _uiElementMock2.Setup(ui => ui.Width).Returns(3);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            HStack.AddChild(_uiElementMock2.Object);
            //assert
            Assert.Equal(5, HStack.Width);
        }
        [Fact]
        public void Width_should_be_3_when_1_element_Width_1_in_it_with_border_thickness_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(3, HStack.Width);
        }
        [Fact]
        public void Width_should_be_4_when_1_element_Width_2_in_it_with_border_thickness_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(2);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(4, HStack.Width);
        }
        [Fact]
        public void Width_should_be_6_when_1_element_Width_4_in_it_with_border_thickness_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(4);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(6, HStack.Width);
        }
        [Fact]
        public void Width_should_be_5_when_1_element_Width_1_in_it_with_border_thickness_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(5, HStack.Width);
        }
        [Fact]
        public void Width_should_be_6_when_1_element_Width_2_in_it_with_border_thickness_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(2);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(6, HStack.Width);
        }
        [Fact]
        public void Width_should_be_7_when_1_element_Width_3_in_it_with_border_thickness_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(3);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(7, HStack.Width);
        }
        [Fact]
        public void Width_should_be_7_when_1_element_Width_1_in_it_with_border_thickness_3()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(3);
            HStack.Border = _borderMock.Object;
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(7, HStack.Width);
        }
        //should test with width


        [Fact]
        public void Width_Height_should_be_1_1_when_HStack_declared_with_1_1_Bound()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(1, 1));
            //assert
            Assert.Equal(1, HStack.Width);
            Assert.Equal(1, HStack.Height);
        }
        [Fact]
        public void Width_Height_should_be_2_3_when_HStack_declared_with_2_3_Bound()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(2, 3));
            //assert
            Assert.Equal(3, HStack.Width);
            Assert.Equal(2, HStack.Height);
        }
        [Fact]
        public void Width_Height_should_be_3_3_when_HStack_declared_with_0_3_Bound_and_1_element_of_Width_3()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(3);
            _uiElementMock1.Setup(ui => ui.Height).Returns(1);
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(0, 3));
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(3, HStack.Width);
            Assert.Equal(1, HStack.Height);
        }
        [Fact]
        public void Width_Height_should_be_5_3_when_HStack_declared_with_0_3_Bound_and_1_element_of_Width_5()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(5);
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(3, 0));
            HStack.AddChild(_uiElementMock1.Object);
            //assert
            Assert.Equal(5, HStack.Width);
            Assert.Equal(3, HStack.Height);
        }
        [Fact]
        public void Width_Width_should_be_4_5_when_HStack_declared_with_0_0_Bound_and_2_element_of_Width_1_3_and_width_1_5()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            _uiElementMock2.Setup(ui => ui.Width).Returns(3);
            _uiElementMock1.Setup(ui => ui.Height).Returns(1);
            _uiElementMock2.Setup(ui => ui.Height).Returns(5);
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(0, 0));
            HStack.AddChild(_uiElementMock1.Object);
            HStack.AddChild(_uiElementMock2.Object);
            //assert
            Assert.Equal(4, HStack.Width);
            Assert.Equal(5, HStack.Height);
        }
        [Fact]
        public void Width_Width_should_be_8_9_when_HStack_declared_with_0_0_Bound_and_2_element_of_Width_1_3_and_width_1_5_with_border_thickness_2()
        {
            //arrange
            _uiElementMock1.Setup(ui => ui.Width).Returns(1);
            _uiElementMock2.Setup(ui => ui.Width).Returns(3);
            _uiElementMock1.Setup(ui => ui.Height).Returns(1);
            _uiElementMock2.Setup(ui => ui.Height).Returns(5);
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            //act
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object, new Bound(0, 0));
            HStack.AddChild(_uiElementMock1.Object);
            HStack.AddChild(_uiElementMock2.Object);
            //assert
            Assert.Equal(8, HStack.Width);
            Assert.Equal(9, HStack.Height);
        }
        //GetGlbalPosition Tests
        [Fact]
        public void GetGlobalPosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(0, position.y);
            Assert.Equal(0, position.x);
        }
        [Fact]
        public void GetGlobalPosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetGlobalPosition_should_return_3_2_when_parent_at_3_2_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(3, 2), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(3, position.y);
            Assert.Equal(2, position.x);
        }
        [Fact]
        public void GetGlobalPosition_should_return_2_2_when_parent_at_1_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(1, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(1, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetGlobalPosition_should_return_3_2_when_parent_at_2_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetGlobalPosition_should_return_4_3_when_parent_at_2_1_and_border_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetGlobalPosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
    }
}
