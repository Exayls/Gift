using Gift.ApplicationService.Services;
using Gift.Displayer.Rendering;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.Repository;
using Moq;
using System;
using System.IO;
using System.Text;
using TestGift;
using Xunit;

namespace Gift.Displayer.Tests.Integration
{
    public class GiftVStackTest
    {
        private Mock<IScreenDisplay> _screenDisplayMock1;
        private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;

        public GiftVStackTest()
        {
            _screenDisplayMock1 = new Mock<IScreenDisplay>();
            _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
            _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Size>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
        }

        [Fact]
        public void TestVStack()
        {
            GiftUI ui = CreateUI(new Size(20, 60));
            var vstack = CreateVstack();
            ui.Add(vstack);

            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();

            var expectedBuilder = new StringBuilder();
            string expected;
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
                expected = expectedBuilder.ToString();
                Assert.Equal(expected, actual[i]);
            }
        }

        private UIElement CreateVstack()
        {
            var vstack = new VStackBuilder().Build();
            return vstack;
        }

        private static GiftUI CreateUI(Size bound)
        {
            GiftUI ui = new GiftUIBuilder().WithBound(bound).Build();
            return ui;
        }

        [Fact]
        public void TestVStackWithLabelImplicit()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = CreateUI(new Size(20, 60));
            var vstack = new VStackBuilder().Build();
            var label = new LabelBuilder().Build();
            ui.Add(vstack);
            vstack.Add(label);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(20, 60));
            var vstack = new VStackBuilder().Build();
            var label = new LabelBuilder().Build();
            ui.Add(vstack);
            vstack.Add(label);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            ui.Add(vstack);
            vstack.Add(label1);
            vstack.Add(label2);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            ui.Add(vstack);
            vstack.Add(label1);
            vstack.Add(label2);
            vstack.Add(label3);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(20, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").WithPosition(new Position(4, 8)).Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            ui.Add(vstack);
            vstack.Add(label1);
            vstack.Add(label2);
            vstack.Add(label3);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(4, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            var label4 = new LabelBuilder().WithText("label numero 4.").Build();
            var label5 = new LabelBuilder().WithText("label numero 5.").Build();
            ui.Add(vstack);
            vstack.Add(label1);
            vstack.Add(label2);
            vstack.Add(label3);
            vstack.Add(label4);
            vstack.Add(label5);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);
            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
            var ui = CreateUI(new Size(4, 60));
            var vstack = new VStackBuilder().Build();
            var label1 = new LabelBuilder().Build();
            var label2 = new LabelBuilder().WithText("test").Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").Build();
            var label4 = new LabelBuilder().WithText("label numero 4.").Build();
            var label5 = new LabelBuilder().WithText("label numero 5.").Build();
            var label6 = new LabelBuilder().WithText("label numero 6.").Build();
            ui.Add(vstack);
            vstack.Add(label1);
            vstack.Add(label2);
            vstack.Add(label3);
            vstack.Add(label4);
            vstack.Add(label5);
            vstack.Add(label6);
            IRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Size.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Size.Width));
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
			var repository = Mock.Of<IRepository>();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Size(2, 4), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new Size(3, 4), '*', new ColorResolver(repository));
            //assert
            const string expected = "----\n" +
                                    "-**-\n" +
                                    "----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            //arrange
            var vstack = new VStackBuilder().
                WithBorder(new SimpleBorder(1, 'i')).
                Build();
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(3, 4), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(5, 5), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(3, 6), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(5, 5), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(6, 7), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(7, 7), '*', new ColorResolver(repository));
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
            IRepository repository = new InMemoryRepository();
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplayWithBorder(new(7, 7), '*', new ColorResolver(repository));
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
