﻿using Gift.Displayer.Rendering;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.Repository;
using Gift.XmlUiParser.Tests.Helper;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace TestGift.Test.UI
{
    public class RendererTest
    {
        private readonly ITestOutputHelper _output;

        public RendererTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private static Renderer GetRenderer(IRepository repository)
        {
            return new Renderer(new DefaultConfiguration(), new ColorResolver(repository), new TrueElementSizeCalculator(repository));
        }

        [Fact]
        public void Can_render_Simple_UI()
        {
            InMemoryRepository repository = new InMemoryRepository();
            var renderer = GetRenderer(repository);
            GiftUI ui = CreateGiftUi(new Size(5, 10), new NoBorder());
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
            repository.SaveRoot(ui);
            // clang-format off
            const string expected = "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********\n" +
                                    "**********";
            // clang-format on
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }

        private static GiftUI CreateGiftUi(Size bound, IBorder border)
        {
            return new GiftUIBuilder().WithBound(bound).WithBorder(border).Build();
        }

        [Fact]
        public void Can_render_UI_with_elements()
        {
            GiftUI ui = CreateGiftUi(new Size(10, 10), new NoBorder());

            VStack vstack = new VStackBuilder()
                                .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                      "ressources/borderchars/double_border.json")))
                                .WithBound(new(-1, -1))
                                .Build();
            vstack.Add(new LabelBuilder().Build());
            ui.Add(vstack);
            VStack vstack2 = new VStackBuilder()
                                 .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                       "ressources/borderchars/simple_border.json")))
                                 .Build();
            vstack.Add(vstack2);
            vstack2.Add(new LabelBuilder().WithText("hey").Build());
            vstack2.Add(new LabelBuilder().Build());
            InMemoryRepository repository = new InMemoryRepository();
            var renderer = GetRenderer(repository);
            repository.SaveRoot(ui);
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
            // clang-format off
            const string expected = "╔════════╗\n" +
                                    "║Hello***║\n" +
                                    "║┌─────┐*║\n" +
                                    "║│hey**│*║\n" +
                                    "║│Hello│*║\n" +
                                    "║└─────┘*║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "╚════════╝";
            // clang-format on
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }

        [Fact]
        public void Can_render_UI_with_root_border()
        {

            VStack vstack = new VStackBuilder()
                                .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                      "ressources/borderchars/double_border.json")))
                                .WithBound(new(4, 4))
                                .Build();
            vstack.Add(new LabelBuilder().WithText("b").Build());
            VStack vstack2 = new VStackBuilder()
                                 .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                       "ressources/borderchars/simple_border.json")))
                                 .Build();
            InMemoryRepository repository = new InMemoryRepository();
            var renderer = GetRenderer(repository);
            repository.SaveRoot(vstack);
            IScreenDisplay rendered = renderer.GetRenderDisplay(vstack);
            // clang-format off
            const string expected = "╔══╗\n" +
                                    "║b*║\n" +
                                    "║**║\n" +
                                    "╚══╝";
            // clang-format on
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }

        [Fact]
        public void Can_render_UI_with_elements_out_of_bound()
        {
            GiftUI ui = CreateGiftUi(new Size(10, 10), new NoBorder());

            VStack vstack = new VStackBuilder()
                                .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                      "ressources/borderchars/double_border.json")))
                                .WithBound(new(-1, -1))
                                .Build();
            vstack.Add(new LabelBuilder().Build());
            ui.Add(vstack);
            VStack vstack2 = new VStackBuilder()
                                 .WithBorder(new DetailedBorder(1, BorderOption.GetBorderCharsFromFile(
                                                                       "ressources/borderchars/simple_border.json")))
                                 .Build();
            vstack.Add(vstack2);
            vstack2.Add(new LabelBuilder().WithText("hey").Build());
            vstack2.Add(
                new LabelBuilder().WithText("test6").WithPosition(new Position(-2, 3)).Build());
            vstack2.Add(new LabelBuilder().Build());
            InMemoryRepository repository = new InMemoryRepository();
            var renderer = GetRenderer(repository);
            repository.SaveRoot(ui);
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);

            // clang-format off
            const string expected = "╔════════╗\n" +
                                    "║Hello***║\n" +
                                    "║┌─────┐*║\n" +
                                    "║│hey**│*║\n" +
                                    "║│Hello│*║\n" +
                                    "║└─────┘*║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "║********║\n" +
                                    "╚════════╝";
            // clang-format on
            Assert.Equal(expected, rendered.DisplayString.ToString());
        }

        [Fact]
        public void Can_render_color_of_border()
        {
            GiftUI ui = CreateGiftUi(new Size(4, 10), new NoBorder());

            VStack vstack =
                new VStackBuilder()
                    .WithBorder(new SimpleBorder(1, '-'))
                    .WithForegroundColor(Color.Red)
                    .WithBound(new(-1, -1))
                    .Build();
            vstack.Add(new LabelBuilder().Build());
            ui.Add(vstack);

            InMemoryRepository repository = new InMemoryRepository();
            var renderer = GetRenderer(repository);
            repository.SaveRoot(ui);
            IScreenDisplay rendered = renderer.GetRenderDisplay(ui);
            // clang-format off
            Color[,] expected =
            {
                {Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red },
                {Color.Red, Color.White, Color.White, Color.White, Color.White, Color.White, Color.Red, Color.Red, Color.Red, Color.Red },
                {Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red },
                {Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red },
            };

            // clang-format on
            var logger = LoggerHelper.GetLogger<RendererTest>(_output);

            Print2DArray(expected, logger);
            Print2DArray(rendered.FrontColorMap, logger);
            Print2DArray(rendered.DisplayMap, logger);
            // foreach (Color line in expected.Length)
            // {
            //     logger.LogTrace(line.ToString());
            // }

            Assert.Equal(expected, rendered.FrontColorMap);
        }

        private static void Print2DArray<T>(T[,] matrix, ILogger logger)
        {
            string line = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j]?.ToString() ?? "" + " ";
                }
                line += "\n";
            }
            logger.LogTrace(line);
        }
    }
}
