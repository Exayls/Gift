
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using TestGift.Mocks;
using Xunit;

namespace TestGift.UnitTest.UI.Element
{
    public class HStackTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<UIElement> _uiElementMock1;
        private Mock<UIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private HStack HStack;

        public HStackTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<UIElement>();
            _uiElementMock2 = new Mock<UIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            HStack = new HStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
        }

        private HStack CreateHstack(IBorder? border = null, Bound? bound = null)
        {
            if (border == null)
            {
                border = new NoBorder();
            }
            if (bound == null)
            {
                bound = new Bound(0, 0);
            }
            return new HStack(border, new ScreenDisplayFactory(), bound);
        }

        private MockUIElement CreateUIElement(int height = 1, int width = 1, bool isFixed = false)
        {
            return new MockUIElement(height, width);
        }

        private static void AssertScreenDisplayEquals(string expected, IScreenDisplay screenDisplay)
        {
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        private IScreenDisplay GetScreenDisplay(HStack hstack, char charFill = '*')
        {
            return hstack.GetDisplayWithBorder(new(hstack.Height, hstack.Width), charFill);
        }

        //GetDisplay tests
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whith_no_border()
        {
            //arrange

            Bound bound = new(2, 4);
            HStack = CreateHstack(bound: bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);

            const string expected = "****\n" +
                                    "****";
            //assert
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            //arrange
            Bound bound = new Bound(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "----\n" +
                                    "-**-\n" +
                                    "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            //arrange
            Bound bound = new Bound(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack, 'i');
            //assert
            const string expected = "----\n" +
                                    "-ii-\n" +
                                    "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            //arrange
            Bound bound = new Bound(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, 'i'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "iiii\n" +
                                    "i**i\n" +
                                    "iiii";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            //arrange
            Bound bound = new Bound(5, 5);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "-----\n" +
                                    "-***-\n" +
                                    "-***-\n" +
                                    "-***-\n" +
                                    "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        {
            //arrange
            Bound bound = new Bound(3, 6);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "------\n" +
                                    "-****-\n" +
                                    "------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        {
            //arrange
            Bound bound = new Bound(5, 5);
            HStack = CreateHstack(new SimpleBorder(2, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "-----\n" +
                                    "-----\n" +
                                    "--*--\n" +
                                    "-----\n" +
                                    "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        {
            //arrange
            Bound bound = new Bound(6, 7);
            HStack = CreateHstack(new SimpleBorder(2, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "--***--\n" +
                                    "--***--\n" +
                                    "-------\n" +
                                    "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        {
            //arrange
            Bound bound = new Bound(7, 7);
            HStack = CreateHstack(new SimpleBorder(3, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "---*---\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness4()
        {
            //arrange
            Bound bound = new Bound(7, 7);
            HStack = CreateHstack(new SimpleBorder(3, '-'), bound);
            //act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack, charFill: 'b');
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "---b---\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        //GetContext tests
        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_HStack_has_no_border()
        {
            //arrange
            UIElement uielement = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(0, 'a'));
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Context context = HStack.GetContextRelativeRenderable(uielement, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_1()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 1);
            UIElement uielement2 = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRelativeRenderable(uielement2, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(1, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_2()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 2);
            UIElement uielement2 = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRelativeRenderable(uielement2, contextRenderable);
            //assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(2, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_1_1_bound_when_HStack_has_child_with_height_of_1_and_width_1()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 1, height: 1);
            UIElement uielement2 = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            Context contextRenderable = new Context(new Position(0, 0), new Bound(5, 5));
            //act
            Context context = HStack.GetContextRelativeRenderable(uielement2, contextRenderable);
            //assert
            Assert.Equal(1, context.Bounds.Width);
            Assert.Equal(1, context.Bounds.Height);
        }


        //Height/Width Tests

        [Fact]
        public void Width_should_be_1_when_1_element_Width_1_in_it_with_no_border()
        {
            //arrange
			HStack = CreateHstack();
            UIElement uielement1 = CreateUIElement(width: 1);
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(1, HStack.Width);
        }

        [Fact]
        public void Width_should_be_4_when_2_element_Width_2_in_it_with_no_border()
        {
            //arrange
			HStack = CreateHstack();
            UIElement uielement1 = CreateUIElement(width: 2);
            UIElement uielement2 = CreateUIElement(width: 2);
            //act
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(4, HStack.Width);
        }

        [Fact]
        public void Width_should_be_5_when_2_element_Width_total_is_5_in_it_with_no_border()
        {
            //arrange
			HStack = CreateHstack();
            UIElement uielement1 = CreateUIElement(width: 2);
            UIElement uielement2 = CreateUIElement(width: 3);
            //act
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(5, HStack.Width);
        }

        [Fact]
        public void Width_should_be_3_when_1_element_Width_1_in_it_with_border_thickness_1()
        {
            //arrange
			HStack = CreateHstack(new SimpleBorder(1, 'a'));
            UIElement uielement1 = CreateUIElement(width: 1);
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(3, HStack.Width);
        }

        [Fact]
        public void Width_should_be_4_when_1_element_Width_2_in_it_with_border_thickness_1()
        {
            //arrange
			HStack = CreateHstack(new SimpleBorder(1, 'a'));
            UIElement uielement1 = CreateUIElement(width: 2);
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(4, HStack.Width);
        }

        [Fact]
        public void Width_should_be_6_when_1_element_Width_4_in_it_with_border_thickness_1()
        {
            //arrange
			HStack = CreateHstack(new SimpleBorder(1, 'a'));
            UIElement uielement1 = CreateUIElement(width: 4);
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(6, HStack.Width);
        }

        [Fact]
        public void Width_should_be_5_when_1_element_Width_1_in_it_with_border_thickness_2()
        {
            //arrange
			HStack = CreateHstack(new SimpleBorder(2, 'a'));
            UIElement uielement1 = CreateUIElement(width: 1);
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(5, HStack.Width);
        }

        [Fact]
        public void Width_should_be_6_when_1_element_Width_2_in_it_with_border_thickness_2()
        {
            //arrange
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            MockUIElement uIElement = CreateUIElement(width: 2);
            //act
            HStack.AddUnselectableChild(uIElement);
            //assert
            Assert.Equal(6, HStack.Width);
        }
        [Fact]
        public void Width_should_be_7_when_1_element_Width_3_in_it_with_border_thickness_2()
        {
            //arrange
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            MockUIElement uIElement = CreateUIElement(width: 3);
            //act
            HStack.AddUnselectableChild(uIElement);
            //assert
            Assert.Equal(7, HStack.Width);
        }

        [Fact]
        public void Width_should_be_7_when_1_element_Width_1_in_it_with_border_thickness_3()
        {
            //arrange
            HStack = CreateHstack(border: new SimpleBorder(3, 'a'));
            MockUIElement uIElement = CreateUIElement(width: 1);
            //act
            HStack.AddUnselectableChild(uIElement);
            //assert
            Assert.Equal(7, HStack.Width);
        }


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
            UIElement uielement1 = CreateUIElement(width: 3, height: 1);
            HStack = CreateHstack(bound: new Bound(0,3));
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(3, HStack.Width);
            Assert.Equal(1, HStack.Height);
        }
        [Fact]
        public void Width_Height_should_be_5_3_when_HStack_declared_with_0_3_Bound_and_1_element_of_Width_5()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 5);
            HStack = CreateHstack(bound: new Bound(3,0));
            //act
            HStack.AddUnselectableChild(uielement1);
            //assert
            Assert.Equal(5, HStack.Width);
            Assert.Equal(3, HStack.Height);
        }
        [Fact]
        public void Width_Height_should_be_4_5_when_HStack_declared_with_0_0_Bound_and_2_element_of_Width_1_3_and_width_1_5()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 1, height: 1);
            UIElement uielement2 = CreateUIElement(width: 3, height: 5);
            HStack = CreateHstack();
            //act
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(4, HStack.Width);
            Assert.Equal(5, HStack.Height);
        }
        [Fact]
        public void Width_Width_should_be_8_9_when_HStack_declared_with_0_0_Bound_and_2_element_of_Width_1_3_and_width_1_5_with_border_thickness_2()
        {
            //arrange
            UIElement uielement1 = CreateUIElement(width: 1, height: 1);
            UIElement uielement2 = CreateUIElement(width: 3, height: 5);
            HStack = CreateHstack(new SimpleBorder(2,'*'));
            //act
            HStack.AddUnselectableChild(uielement1);
            HStack.AddUnselectableChild(uielement2);
            //assert
            Assert.Equal(8, HStack.Width);
            Assert.Equal(9, HStack.Height);
        }
        //GetGlbalPosition Tests
        [Fact]
        public void GetRelativePosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(0, position.y);
            Assert.Equal(0, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_3_2_and_no_border()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(3, 2), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(3, position.y);
            Assert.Equal(2, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_2_when_parent_at_1_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(1, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(1, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_2_1_and_border_1()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_4_3_when_parent_at_2_1_and_border_2()
        {
            //arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            HStack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Bound(0, 0));
            //act
            Position position = HStack.GetRelativePosition(contextRenderable);
            //assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
    }
}
