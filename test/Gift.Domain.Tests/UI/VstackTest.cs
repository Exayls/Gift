﻿using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using TestGift.Mocks;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class VstackTest
    {

        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<UIElement> _uiElementMock1;
        private Mock<UIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private VStack vstack;
        private readonly IRepository _repository;

        public VstackTest()
        {
			_repository = Mock.Of<IRepository>();
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<UIElement>();
            _uiElementMock2 = new Mock<UIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock
                .Setup(s => s.Create(It.IsAny<Size>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>()))
                .Returns(_screenDisplayMock1.Object);
            vstack = new VStackBuilder().WithBorder(_borderMock.Object).Build();
        }

        private VStack CreateVstack(IBorder? border = null, Size? bound = null)
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

        private MockUIElement CreateUIElement(int height = 0, int width = 0, bool isFixed = false)
        {
            return new MockUIElement(height, width, isFixed);
        }

        private static void AssertScreenDisplayEquals(string expected, IScreenDisplay screenDisplay)
        {
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        private IScreenDisplay GetScreenDisplay(VStack vstack, char charFill = '*')
        {
            return vstack.GetDisplayWithBorder(new(vstack.Height, vstack.Width), charFill, new ColorResolver(_repository));
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
            Context contextRenderable = new Context(new Position(0, 0), new Size(0, 0));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness1()
        {
            // arrange
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            UIElement uielement = CreateUIElement();
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_0_0_position_when_vstack_has_border_thickness2()
        {
            // arrange
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            UIElement uielement = CreateUIElement();
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(0, context.Position.y);
            Assert.Equal(0, context.Position.x);
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
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement1, contextRenderable);
            // assert
            Assert.Equal(1, context.Position.y);
            Assert.Equal(0, context.Position.x);
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
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            Context context = vstack.GetContext(uielement2, contextRenderable);
            // assert
            Assert.Equal(2, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_1_bound_when_vstack_has_child_with_height_of_1_and_width_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            // act
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_5_bound_when_vstack_has_child_with_height_of_1_and_width_5()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1, width: 5);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(5, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_1_3_bound_when_vstack_has_child_with_height_of_1_and_width_3()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1, width: 3);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(1, context.Bounds.Height);
            Assert.Equal(3, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_2_1_bound_when_vstack_has_child_with_height_of_2_and_width_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 2, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(2, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }
        [Fact]
        public void GetContext_should_return_context_with_3_1_bound_when_vstack_has_child_with_height_of_3_and_width_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(3, context.Bounds.Height);
            Assert.Equal(1, context.Bounds.Width);
        }

        [Fact]
        public void GetContext_should_return_context_with_minus1_0_position_when_vstack_has_scrollDown()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            vstack.ScrollDown();
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(-1, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        [Fact]
        public void GetContext_should_return_context_with_1_0_position_when_vstack_has_scrollUp()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3, width: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            vstack.Add(uielement);
            vstack.ScrollUp();
            Context contextRenderable = new Context(new Position(0, 0), new Size(5, 5));
            // act
            Context context = vstack.GetContext(uielement, contextRenderable);
            // assert
            Assert.Equal(1, context.Position.y);
            Assert.Equal(0, context.Position.x);
        }

        // Height/Width Tests
        [Fact]
        public void Height_should_be_1_when_1_element_height_1_in_it_with_no_border()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack();
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(1, vstack.Height);
        }
        [Fact]
        public void Height_should_be_4_when_2_element_height_2_in_it_with_no_border()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 2);
            vstack = CreateVstack();
            // act
            vstack.Add(uielement1);
            vstack.Add(uielement2);
            // assert
            Assert.Equal(4, vstack.Height);
        }
        [Fact]
        public void Height_should_be_5_when_2_element_height_total_is_5_in_it_with_no_border()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(height: 2);
            UIElement uielement2 = CreateUIElement(height: 3);
            vstack = CreateVstack();
            // act
            vstack.Add(uielement1);
            vstack.Add(uielement2);
            // assert
            Assert.Equal(5, vstack.Height);
        }
        [Fact]
        public void Height_should_be_3_when_1_element_height_1_in_it_with_border_thickness_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(3, vstack.Height);
        }
        [Fact]
        public void Height_should_be_4_when_1_element_height_2_in_it_with_border_thickness_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(4, vstack.Height);
        }

        [Fact]
        public void Height_should_be_6_when_1_element_height_4_in_it_with_border_thickness_1()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 4);
            vstack = CreateVstack(border: new SimpleBorder(1, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(6, vstack.Height);
        }
        [Fact]
        public void Height_should_be_5_when_1_element_height_1_in_it_with_border_thickness_2()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(5, vstack.Height);
        }

        [Fact]
        public void Height_should_be_6_when_1_element_height_2_in_it_with_border_thickness_2()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 2);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(6, vstack.Height);
        }

        [Fact]
        public void Height_should_be_7_when_1_element_height_3_in_it_with_border_thickness_2()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3);
            vstack = CreateVstack(border: new SimpleBorder(2, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(7, vstack.Height);
        }

        [Fact]
        public void Height_should_be_7_when_1_element_height_1_in_it_with_border_thickness_3()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 1);
            vstack = CreateVstack(border: new SimpleBorder(3, 'a'));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(7, vstack.Height);
        }
        // should test with width

        [Fact]
        public void Height_Width_should_be_1_1_when_vstack_declared_with_1_1_Bound()
        {
            // arrange
            vstack = CreateVstack(bound: new Size(1, 1));
            // assert
            Assert.Equal(1, vstack.Height);
            Assert.Equal(1, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_2_3_when_vstack_declared_with_2_3_Bound()
        {
            // arrange
            vstack = CreateVstack(bound: new Size(2, 3));
            // assert
            Assert.Equal(2, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_3_3_when_vstack_declared_with_0_3_Bound_and_1_element_of_height_3()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 3);
            vstack = CreateVstack(bound: new Size(0, 3));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(3, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void Height_Width_should_be_5_3_when_vstack_declared_with_0_3_Bound_and_1_element_of_height_5()
        {
            // arrange
            UIElement uielement = CreateUIElement(height: 5);
            vstack = CreateVstack(bound: new Size(0, 3));
            // act
            vstack.Add(uielement);
            // assert
            Assert.Equal(5, vstack.Height);
            Assert.Equal(3, vstack.Width);
        }
        [Fact]
        public void
        Height_Width_should_be_4_5_when_vstack_declared_with_0_0_Bound_and_2_element_of_height_1_3_and_width_1_5()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(height: 1, width: 1);
            UIElement uielement2 = CreateUIElement(height: 3, width: 5);
            vstack = CreateVstack();
            // act
            vstack.Add(uielement1);
            vstack.Add(uielement2);
            // assert
            Assert.Equal(4, vstack.Height);
            Assert.Equal(5, vstack.Width);
        }
        [Fact]
        public void
        Height_Width_should_be_8_9_when_vstack_declared_with_0_0_Bound_and_2_element_of_height_1_3_and_width_1_5_with_border_thickness_2()
        {
            // arrange
            UIElement uielement1 = CreateUIElement(1, 1);
            UIElement uielement2 = CreateUIElement(3, 5);
            vstack = CreateVstack(border: new SimpleBorder(2, '+'));
            // act
            vstack.Add(uielement1);
            vstack.Add(uielement2);
            // assert
            Assert.Equal(8, vstack.Height);
            Assert.Equal(9, vstack.Width);
        }

        // GetGlbalPosition Tests
        [Fact]
        public void GetRelativePosition_should_return_0_0_when_parent_at_0_0_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(0, 0), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(0, position.y);
            Assert.Equal(0, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_1_when_parent_at_2_1_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_3_2_and_no_border()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(0);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(3, 2), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(3, position.y);
            Assert.Equal(2, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_2_2_when_parent_at_1_1_and_border_1()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(1, 1), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(1, position.y);
            Assert.Equal(1, position.x);
        }
        [Fact]
        public void GetRelativePosition_should_return_3_2_when_parent_at_2_1_and_border_1()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(1);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }

        [Fact]
        public void GetRelativePosition_should_return_4_3_when_parent_at_2_1_and_border_2()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }

        [Fact]
        public void GetRelativePosition_should_return_3_3_when_parent_at_2_1_and_border_2()
        {
            // arrange
            _borderMock.Setup(b => b.Thickness).Returns(2);
            vstack.Border = _borderMock.Object;
            Context contextRenderable = new Context(new Position(2, 1), new Size(0, 0));
            // act
            Position position = vstack.GetRelativePosition(contextRenderable);
            // assert
            Assert.Equal(2, position.y);
            Assert.Equal(1, position.x);
        }
    }
}
