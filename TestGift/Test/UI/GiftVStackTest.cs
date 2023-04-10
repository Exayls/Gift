using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using Moq;
using System.Text;

namespace TestGift.UI
{
    public class GiftVStackTest
    {
        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplay> _screenDisplayMock2;
        private Mock<IUIElement> _uiElementMock1;
        private Mock<IUIElement> _uiElementMock2;
        private Mock<IBorder> _borderMock;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
        private VStack vstack;

        public GiftVStackTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _screenDisplayMock2 = new Mock<IScreenDisplay>();
            _uiElementMock1 = new Mock<IUIElement>();
            _uiElementMock2 = new Mock<IUIElement>();
            _borderMock = new Mock<IBorder>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
            vstack = new VStack(_borderMock.Object, _ScreenDisplayFactoryMock.Object);
        }

        [Fact]
        public void TestVStack()
        {
            GiftUI ui = CreateUI(new Bound(20, 60));
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();

            var expectedBuilder = new StringBuilder();
            string expected;
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                Assert.Equal(expected, actual[i]);
            }
        }

        private static GiftUI CreateUI(Bound bound)
        {
            GiftUI ui = new GiftUI(bound);
            var vstack = new VStackBuilder().Build();
            ui.SetChild(vstack);
            return ui;
        }

        [Fact]
        public void TestVStackWithLabelImplicit()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(20, 60));
            var vstack = new VStackBuilder().Build();
            var label = new LabelBuilder().Build();
            ui.SetChild(vstack);
            vstack.AddChild(label);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void TestVStackWithLabelExplicit()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(20, 60));
            var vstack = new VStackBuilder().Build();
            var label = new LabelBuilder().Build();
            ui.SetChild(vstack);
            vstack.AddChild(label);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }

        [Fact]
        public void TestVStackWith2LabelsImplicit()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "test", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }

        [Fact]
        public void TestVStackWith3LabelsImplicit()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "test", 0);
                }
                if (i == 2)
                {
                    expected = TestHelper.Replace(expected, "label numero 3.", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }

        [Fact]
        public void TestVStackWithExplicitLabel()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").WithPosition(new Position(4, 8)).Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                if (i == 4)
                {
                    expected = TestHelper.Replace(expected, "test", 8);
                }
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "label numero 3.", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }

        [Fact]
        public void TestVStackWithTooMuchElement()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(4, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            var label4 = new LabelBuilder().WithText("label numero 4.").Build();
            var label5 = new LabelBuilder().WithText("label numero 5.").Build();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            vstack.AddChild(label4);
            vstack.AddChild(label5);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);
            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "test", 0);
                }
                if (i == 2)
                {
                    expected = TestHelper.Replace(expected, "label numero 3.", 0);
                }
                if (i == 3)
                {
                    expected = TestHelper.Replace(expected, "label numero 4.", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void TestVStackWithTooMuchElement2()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = new GiftUI(new Bound(4, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            var label4 = new LabelBuilder().WithText("label numero 4.").Build();
            var label5 = new LabelBuilder().WithText("label numero 5.").Build();
            var label6 = new LabelBuilder().WithText("label numero 6.").Build();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            vstack.AddChild(label4);
            vstack.AddChild(label5);
            vstack.AddChild(label6);
            IScreenDisplay renderedText = new Renderer().GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "test", 0);
                }
                if (i == 2)
                {
                    expected = TestHelper.Replace(expected, "label numero 3.", 0);
                }
                if (i == 3)
                {
                    expected = TestHelper.Replace(expected, "label numero 4.", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }

        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whithout_border()
        {
            var vstack = new VStackBuilder().
                WithBorder(new NoBorder()).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Bound(2, 4), '*');
            //assert
            const string expected = "****\n" +
                                    "****";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Bound(3, 4), '*');
            //assert
            const string expected = "----\n" +
                                    "-**-\n" +
                                    "----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, '_')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
            //assert
            const string expected = "____\n" +
                                    "_**_\n" +
                                    "____";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, 'i')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
            //assert
            const string expected = "iiii\n" +
                                    "i**i\n" +
                                    "iiii";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(5, 5));
            //assert
            const string expected = "-----\n" +
                                    "-***-\n" +
                                    "-***-\n" +
                                    "-***-\n" +
                                    "-----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 6));
            //assert
            const string expected = "------\n" +
                                    "-****-\n" +
                                    "------";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(2, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(5, 5));
            //assert
            const string expected = "-----\n" +
                                    "-----\n" +
                                    "--*--\n" +
                                    "-----\n" +
                                    "-----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(2, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(6, 7));
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "--***--\n" +
                                    "--***--\n" +
                                    "-------\n" +
                                    "-------";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(3, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(7, 7));
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "---*---\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "-------";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness4()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(3, '-')).
                Build();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(7, 7));
            //assert
            const string expected = "-------\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "---*---\n" +
                                    "-------\n" +
                                    "-------\n" +
                                    "-------";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
    }
}
