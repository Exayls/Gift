using System;
using System.Text;
using Xunit;
using System.IO;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Conf;
using Gift.ApplicationService.Services;
using Gift.Displayer.Rendering;
using Gift.Domain.Builders.UIModel;
using Gift.Repository;

namespace TestGift.UI
{
    public class GiftContainerTest
    {
        [Fact]
        public void CanDisplayContainer()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString().Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                Assert.Equal(expected, actual[i]);
            }
        }

        private static GiftUI GetGiftUi(Size bound)
        {
            return new GiftUIBuilder().WithBound(bound).Build();
        }

        [Fact]
        public void CanDisplayTextToPosNeutral()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var element = new LabelBuilder().Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 0);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayTextToPosFirstLineAt30()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var position = new Position(0, 30);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 30);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayTextToPosFirstLineAt10()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var position = new Position(0, 10);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 10);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayText2ToPosFirstLineAt10()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var position = new Position(0, 10);
            var element = new LabelBuilder().WithText("test").WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "test", 10);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void DoNotDisplayExcedingBounds60()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var position = new Position(0, 1000);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void DoNotDisplaybarelyExcedingBounds60()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(20, 60));
            var position = new Position(0, 58);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString()?.Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "He", 58);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void DisplayBounds80()
        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(10, 80));
            var position = new Position(0, 58);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString().Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 0)
                {
                    expected = TestHelper.Replace(expected, "Hello", 58);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayTextToPos()

        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(4, 16));
            var position = new Position(2, 10);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString().Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 2)
                {
                    expected = TestHelper.Replace(expected, "Hello", 10);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayTextToPos2()

        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(4, 16));
            var position = new Position(1, 10);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString().Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "Hello", 10);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
        [Fact]
        public void CanDisplayTextToPos3()

        {
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var ui = GetGiftUi(new Size(4, 32));
            var position = new Position(1, 10);
            var element = new LabelBuilder().WithPosition(position).Build();
            ui.Add(element);
            InMemoryRepository repository = new InMemoryRepository();
			repository.SaveRoot(ui);
            IScreenDisplay renderedText = new Renderer(new DefaultConfiguration(), new ColorResolver(repository)).GetRenderDisplay(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.DisplayString.ToString().Split('\n') ?? Array.Empty<string>();
            for (int i = 0; i < ui.Bound.Height; i++)
            {
                expectedBuilder.Clear();
                expectedBuilder.Append(new string(GiftLauncherService.FILLINGCHAR, ui.Bound.Width));
                expected = expectedBuilder.ToString();
                if (i == 1)
                {
                    expected = TestHelper.Replace(expected, "Hello", 10);
                }
                Assert.Equal(expected, actual[i]);
            }
        }
    }
}
