using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using System.Text;
using TestGift.Mocks;
using Xunit;

namespace Gift.Domain.Tests.UnitTest.UI
{
    public class VstackTestTODO
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<UIElement> _uiElementMock1;
        private Mock<UIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private VStack vstack;

        public VstackTestTODO()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<UIElement>();
            _uiElementMock2 = new Mock<UIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            vstack = new VStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
        }

        private VStack CreateVstack(IBorder? border = null, Bound? bound = null)
        {
            if (border == null)
            {
                border = new NoBorder();
            }
            if (bound == null)
            {
                bound = new Bound(0, 0);
            }
            return new VStack(border, new ScreenDisplayFactory(), bound);
        }

        private MockUIElement CreateUIElement(int height = 0, int width = 0, bool isFixed = false)
        {
            return new MockUIElement(height, width, isFixed);
        }

        //GetDisplay tests
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whith_no_border()
        {
            //arrange
            vstack = CreateVstack();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(2, 4), '*');
            //assert
            Assert.Equal(2, screenDisplay.TotalBound.Height);
            Assert.Equal(4, screenDisplay.TotalBound.Width);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            //arrange
            _screenDisplayMock2.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("----\n").Append("-  -\n").Append("----"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Bound(3, 4), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Bound(3, 4), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(3, 4), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(5, 5), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(3, 6), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(5, 5), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(6, 7), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(7, 7), '*');
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
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock2.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(7, 7), 'b');
            //assert
            _screenDisplayMock2.Verify(s => s.AddDisplay(_screenDisplayMock1.Object, It.Is<Position>(p => p.y == 3 && p.x == 3)));
            Assert.Equal(_screenDisplayMock2.Object, screenDisplay);
        }

        //GetContext tests
        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_no_border()
        {
            //arrange
            UIElement uielement = CreateUIElement();
            vstack = CreateVstack(border: new SimpleBorder(0, 'a'));
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness1()
        {
            //arrange
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            UIElement uielement = CreateUIElement();
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness2()
        {
            //arrange
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            UIElement uielement = CreateUIElement();
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_3_2_position_when_vstack_has_border_thickness2_and_1_first_child_with_height_of_1()
        {
            //arrange
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            UIElement uielement2 = CreateUIElement(height: 1);
            UIElement uielement1 = CreateUIElement();
            vstack.AddUnselectableChild(uielement2);
            vstack.AddUnselectableChild(uielement1);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement1, contextRenderable);
            //assert
            Assert.Equal(1, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_4_2_position_when_vstack_has_border_thickness2_and_1_first_child_with_height_of_2()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement1);
            vstack.AddUnselectableChild(uielement2);
            //act
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            Context context = vstack.GetContextRelativeRenderable(uielement2, contextRenderable);
            //assert
            Assert.Equal(2, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_1_bound_when_vstack_has_child_with_height_of_1_and_width_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            //act
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_5_bound_when_vstack_has_child_with_height_of_1_and_width_5()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1, width: 5);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(5, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_3_bound_when_vstack_has_child_with_height_of_1_and_width_3()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1, width: 3);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(3, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_2_1_bound_when_vstack_has_child_with_height_of_2_and_width_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 2, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(2, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_3_1_bound_when_vstack_has_child_with_height_of_3_and_width_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(3, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }

        [Fact]
        public void GetContext_should_return_context_with_minus1_0_position_when_vstack_has_scrollDown()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            vstack.ScrollDown();
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(-1, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_1_0_position_when_vstack_has_scrollUp()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.AddUnselectableChild(uielement);
            vstack.ScrollUp();
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = vstack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(1, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        //Height/Width Tests
        [Fact]
        public void Height_should_be_1_when_1_element_height_1_in_it_with_no_border()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack();
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(1, vstack.Height);
        }
        [Fact]
        public void Height_should_be_4_when_2_element_height_2_in_it_with_no_border()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 2);
            vstack = CreateVstack();
            //act
            vstack.AddUnselectableChild(uielement1);
            vstack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(4, vstack.Height);
        }
        [Fact]
        public void Height_should_be_5_when_2_element_height_total_is_5_in_it_with_no_border()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 3);
            vstack = CreateVstack();
            //act
            vstack.AddUnselectableChild(uielement1);
            vstack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(5, vstack.Height);
        }
        [Fact]
        public void Height_should_be_3_when_1_element_height_1_in_it_with_border_thickness_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(3, vstack.Height);
        }
        [Fact]
        public void Height_should_be_4_when_1_element_height_2_in_it_with_border_thickness_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(4, vstack.Height);
        }

        [Fact]
        public void Height_should_be_6_when_1_element_height_4_in_it_with_border_thickness_1()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 4);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(6, vstack.Height);
        }
        [Fact]
        public void Height_should_be_5_when_1_element_height_1_in_it_with_border_thickness_2()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(5, vstack.Height);
        }

        [Fact]
        public void Height_should_be_6_when_1_element_height_2_in_it_with_border_thickness_2()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(6, vstack.Height);
        }

        [Fact]
        public void Height_should_be_7_when_1_element_height_3_in_it_with_border_thickness_2()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 3);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(7, vstack.Height);
        }

        [Fact]
        public void Height_should_be_7_when_1_element_height_1_in_it_with_border_thickness_3()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(3, 'a'));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(7, vstack.Height);
        }
        //should test with width


        [Fact]
        public void Height_Width_should_be_1_1_when_vstack_declared_with_1_1_Bound()
        {
            //arrange
            vstack = CreateVstack(bound: new Bound(1, 1));
            //assert
            Assert.Equal(1, vstack.Height);
            Assert.Equal(1, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_2_3_when_vstack_declared_with_2_3_Bound()
        {
            //arrange
            vstack = CreateVstack(bound: new Bound(2, 3));
            //assert
            Assert.Equal(2, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_3_3_when_vstack_declared_with_0_3_Bound_and_1_element_of_height_3()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 3);
            vstack = CreateVstack(bound: new Bound(0, 3));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(3, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_5_3_when_vstack_declared_with_0_3_Bound_and_1_element_of_height_5()
        {
            //arrange
            UIElement uielement = CreateUIElement(height: 5);
            vstack = CreateVstack(bound: new Bound(0, 3));
            //act
            vstack.AddUnselectableChild(uielement);
            //assert
            Assert.Equal(5, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_4_5_when_vstack_declared_with_0_0_Bound_and_2_element_of_height_1_3_and_width_1_5()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(height: 1, width: 1);
            UIElement uielement2 = CreateUIElement(height: 3, width: 5);
            vstack = CreateVstack();
            //act
            vstack.AddUnselectableChild(uielement1);
            vstack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(4, vstack.Height);
            Assert.Equal(5, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_8_9_when_vstack_declared_with_0_0_Bound_and_2_element_of_height_1_3_and_width_1_5_with_border_thickness_2()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(1, 1);
            UIElement uielement2 = CreateUIElement(3, 5);
            vstack = CreateVstack(border: new SimpleBorder(2, '+'));
            //act
            vstack.AddUnselectableChild(uielement1);
            vstack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(8, vstack.Height);
            Assert.Equal(9, vstack.Width);
        }

        //GetGlbalPosition Tests
        [Fact]
        public void GetRelativePosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(0, position.y);
            Assert.Equal(0, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_3_2_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(3, 2), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(3, position.y);
            Assert.Equal(2, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_2_when_parent_at_1_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(1, 1), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(1, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_2_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }

        [Fact]
        public void GetRelativePosition_should_return_4_3_when_parent_at_2_1_and_border_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }

        [Fact]
        public void GetRelativePosition_should_return_3_3_when_parent_at_2_1_and_border_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = vstack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
    }
}
