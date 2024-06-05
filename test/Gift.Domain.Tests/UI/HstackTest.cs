using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using TestGift.Mocks;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class HStackTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<UIElement> _uiElementMock1;
        private Mock<UIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private HStack HStack;

        public HStackTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<UIElement>();
            _uiElementMock2 = new Mock<UIElement>();
            _borderMock = new Mock<IBorder>();
            HStack = new HStackBuilder().WithBorder(_borderMock.Object).Build();
        }

        private HStack CreateHstack(IBorder? border = null, Size? bound = null)
        {
            if (border == null)
            {
                border = new NoBorder();
            }
            if (bound == null)
            {
                bound = new Size(0, 0);
            }
            return new HStackBuilder().WithBound(bound).WithBorder(border).Build();
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
            IRepository repository = Mock.Of<IRepository>();
            return hstack.GetDisplayWithBorder(charFill, new ColorResolver(repository), new TrueElementSizeCalculator(repository));
        }

        // GetDisplay tests
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whith_no_border()
        {
            // arrange
            Size bound = new(2, 4);
            HStack = CreateHstack(bound: bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);

            const string expected = "****\n" + "****";
            // assert
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            // arrange
            Size bound = new Size(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "----\n" + "-**-\n" + "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            // arrange
            Size bound = new Size(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack, 'i');
            // assert
            const string expected = "----\n" + "-ii-\n" + "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            // arrange
            Size bound = new Size(3, 4);
            HStack = CreateHstack(new SimpleBorder(1, 'i'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "iiii\n" + "i**i\n" + "iiii";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            // arrange
            Size bound = new Size(5, 5);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "-----\n" + "-***-\n" + "-***-\n" + "-***-\n" + "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        {
            // arrange
            Size bound = new Size(3, 6);
            HStack = CreateHstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "------\n" + "-****-\n" + "------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        {
            // arrange
            Size bound = new Size(5, 5);
            HStack = CreateHstack(new SimpleBorder(2, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "-----\n" + "-----\n" + "--*--\n" + "-----\n" + "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        {
            // arrange
            Size bound = new Size(6, 7);
            HStack = CreateHstack(new SimpleBorder(2, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected = "-------\n" + "-------\n" + "--***--\n" + "--***--\n" + "-------\n" + "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        {
            // arrange
            Size bound = new Size(7, 7);
            HStack = CreateHstack(new SimpleBorder(3, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack);
            // assert
            const string expected =
                "-------\n" + "-------\n" + "-------\n" + "---*---\n" + "-------\n" + "-------\n" + "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness4()
        {
            // arrange
            Size bound = new Size(7, 7);
            HStack = CreateHstack(new SimpleBorder(3, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(hstack: HStack, charFill: 'b');
            // assert
            const string expected =
                "-------\n" + "-------\n" + "-------\n" + "---b---\n" + "-------\n" + "-------\n" + "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        // GetContext tests
        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_HStack_has_no_border()
        {
            // arrange
            UIElement uielement = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(0, 'a'));
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = HStack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.y);
            Assert.Equal(0, context.x);
        }

        [Fact]
        public void
        GetContext_should_return_context_with_0_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_1()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(width: 1);
            UIElement uielement2 = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            HStack.Add(uielement1);
            HStack.Add(uielement2);
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = HStack.GetContext(uielement2, contextRenderable);
            // assert
            Assert.Equal(0, context.y);
            Assert.Equal(2, context.x);
        }

        [Fact]
        public void
        GetContext_should_return_context_with_0_2_position_when_HStack_has_border_thickness2_and_1_first_child_with_Width_of_2()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(width: 2);
            UIElement uielement2 = CreateUIElement();
            HStack = CreateHstack(border: new SimpleBorder(2, 'a'));
            HStack.Add(uielement1);
            HStack.Add(uielement2);
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = HStack.GetContext(uielement2, contextRenderable);
            // assert
            Assert.Equal(0, context.y);
            Assert.Equal(3, context.x);
        }

        // Getrelative Tests
        [Fact]
        public void GetRelativePosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Position contextRenderable = new Position(0, 0);
            // act
            Position position = HStack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(0, position.y);
            Assert.Equal(0, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Position contextRenderable = new Position(2, 1);
            // act
            Position position = HStack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_3_2_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            HStack.Border = _borderMock.Object;
            Position contextRenderable = new Position(3, 2);
            // act
            Position position = HStack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(3, position.y);
            Assert.Equal(2, position.x);
        }
    }
}
