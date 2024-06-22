using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Tests.Mocks;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.UIModel.Services;
using Moq;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class VstackTest
    {

        private readonly Mock<IBorder> _borderMock;
        private VStack vstack;
        private readonly IRepository _repository;

        public VstackTest()
        {
            _repository = Mock.Of<IRepository>();
            _borderMock = new Mock<IBorder>();
            vstack = new VStackBuilder().WithBorder(_borderMock.Object).Build();
        }

        private static VStack CreateVstack(IBorder? border = null, Size? bound = null)
        {
            var builder = new VStackBuilder();
            if (border != null)
            {
                builder.WithBorder(border);
            }
            if (bound != null)
            {
                builder.WithBound(bound);
            }
            return builder.Build();
        }

        private static MockUIElement CreateUIElement(int height = 0, int width = 0, bool isFixed = false)
        {
            return new MockUIElement(height, width, isFixed);
        }

        private static void AssertScreenDisplayEquals(string expected, IScreenDisplay screenDisplay)
        {
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        private IScreenDisplay GetScreenDisplay(VStack vstack, char charFill = '*')
        {
            return vstack.GetDisplayWithBorder(charFill, new ColorResolver(_repository), new TrueElementSizeCalculator(_repository));
        }

        // GetDisplay tests
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whith_no_border()
        {
            // arrange
            Size bound = new(2, 4);
            vstack = CreateVstack(bound: bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "****\n" + "****";

            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            // arrange
            Size bound = new Size(3, 4);
            vstack = CreateVstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "----\n" + "-**-\n" + "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            Size bound = new Size(3, 4);
            vstack = CreateVstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack, 'i');
            // assert
            const string expected = "----\n" + "-ii-\n" + "----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            // arrange
            Size bound = new Size(3, 4);
            vstack = CreateVstack(new SimpleBorder(1, 'i'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "iiii\n" + "i**i\n" + "iiii";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            // arrange
            Size bound = new Size(5, 5);
            vstack = CreateVstack(new SimpleBorder(1, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "-----\n" + "-***-\n" + "-***-\n" + "-***-\n" + "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        {
            // arrange
            Size bound = new Size(5, 5);
            vstack = CreateVstack(new SimpleBorder(2, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "-----\n" + "-----\n" + "--*--\n" + "-----\n" + "-----";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        {
            // arrange
            Size bound = new Size(6, 7);
            vstack = CreateVstack(new SimpleBorder(2, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
            // assert
            const string expected = "-------\n" + "-------\n" + "--***--\n" + "--***--\n" + "-------\n" + "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        {
            // arrange
            Size bound = new Size(7, 7);
            vstack = CreateVstack(new SimpleBorder(3, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack);
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
            vstack = CreateVstack(new SimpleBorder(3, '-'), bound);
            // act
            IScreenDisplay screenDisplay = GetScreenDisplay(vstack: vstack, charFill: 'b');
            // assert
            const string expected =
                "-------\n" + "-------\n" + "-------\n" + "---b---\n" + "-------\n" + "-------\n" + "-------";
            AssertScreenDisplayEquals(expected, screenDisplay);
        }

        // GetContext tests
        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_no_border()
        {
            // arrange
            UIElement uielement = CreateUIElement();
            vstack = CreateVstack(border: new SimpleBorder(0, 'a'));
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness1()
        {
            // arrange
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            UIElement uielement = CreateUIElement();
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness2()
        {
            // arrange
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            UIElement uielement = CreateUIElement();
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void
        GetContext_should_return_context_with_3_2_position_when_vstack_has_border_thickness2_and_1_first_child_with_height_of_1()
        {
            // arrange
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            UIElement uielement2 = CreateUIElement(height: 1);
            UIElement uielement1 = CreateUIElement();
            vstack.Add(uielement2);
            vstack.Add(uielement1);
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement1, contextRenderable);
            // assert
            Assert.Equal(1, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void
        GetContext_should_return_context_with_4_2_position_when_vstack_has_border_thickness2_and_1_first_child_with_height_of_2()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement1);
            vstack.Add(uielement2);
            // act
            Position contextRenderable = new Position(0, 0);
            Position context = vstack.GetContext(uielement2, contextRenderable);
            // assert
            Assert.Equal(2, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void GetContext_should_return_context_with_minus1_0_position_when_vstack_has_scrollDown()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            vstack.ScrollDown();
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(-1, context.Y);
            Assert.Equal(0, context.X);
        }

        [Fact]
        public void GetContext_should_return_context_with_1_0_position_when_vstack_has_scrollUp()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            vstack.ScrollUp();
            Position contextRenderable = new Position(0, 0);
            // act
            Position context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(1, context.Y);
            Assert.Equal(0, context.X);
        }


        // GetGlbalPosition Tests
        [Fact]
        public void GetRelativePosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Position contextRenderable = new Position(0, 0);
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(0, position.Y);
            Assert.Equal(0, position.X);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Position contextRenderable = new Position(2, 1);
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.Y);
            Assert.Equal(1, position.X);
        }
    }
}
