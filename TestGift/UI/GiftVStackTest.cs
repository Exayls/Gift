using Gift;
using Gift.Builders;
using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UI
{
    public class GiftVStackTest
    {
        [Fact]
        public void TestVStack()
        {
            GiftUI ui = CreateUI(new Bound(20, 60));
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();

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
            var label = new LabelBuilder().BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            var label1 = new LabelBuilder().BuildImplicit();
            var label2 = new LabelBuilder().WithText("test").BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            var label1 = new LabelBuilder().BuildImplicit();
            var label2 = new LabelBuilder().WithText("test").BuildImplicit();
            var label3 = new LabelBuilder().WithText("label numero 3.").BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            var label1 = new LabelBuilder().BuildImplicit();
            var label2 = new LabelBuilder().WithText("test").WithPosition(new Position(4, 8)).Build();
            var label3 = new LabelBuilder().WithText("label numero 3.").BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            var label1 = new LabelBuilder().BuildImplicit();
            var label2 = new LabelBuilder().WithText("test").BuildImplicit();
            var label3 = new LabelBuilder().WithText("label numero 3.").BuildImplicit();
            var label4 = new LabelBuilder().WithText("label numero 4.").BuildImplicit();
            var label5 = new LabelBuilder().WithText("label numero 5.").BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            vstack.AddChild(label4);
            vstack.AddChild(label5);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
            var label1 = new LabelBuilder().BuildImplicit();
            var label2 = new LabelBuilder().WithText("test").BuildImplicit();
            var label3 = new LabelBuilder().WithText("label numero 3.").BuildImplicit();
            var label4 = new LabelBuilder().WithText("label numero 4.").BuildImplicit();
            var label5 = new LabelBuilder().WithText("label numero 5.").BuildImplicit();
            var label6 = new LabelBuilder().WithText("label numero 6.").BuildImplicit();
            ui.SetChild(vstack);
            vstack.AddChild(label1);
            vstack.AddChild(label2);
            vstack.AddChild(label3);
            vstack.AddChild(label4);
            vstack.AddChild(label5);
            vstack.AddChild(label6);
            TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

            var expectedBuilder = new StringBuilder();
            string expected = "";
            string[] actual = renderedText.ToString()?.Split('\n') ?? Array.Empty<string>();
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
        //[Fact]
        //public void GetDisplay_should_return_screen_when_call_GetDisplay_whithout_border()
        //{
        //    _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("    \n").Append("    "));
        //    _borderMock.Setup(b => b.Thickness).Returns(0);
        //    _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //    vstack.Border = _borderMock.Object;
        //    //act
        //    IScreenDisplay screenDisplay = vstack.GetDisplay(new(2, 4), '*');
        //    //assert
        //    const string expected = "****\n" +
        //                            "****";
        //    Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //}

        //[Fact]
        //public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        //{
        //    //arrange
        //    _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("----\n").Append("-  -\n").Append("----"));
        //    _borderMock.Setup(b => b.Thickness).Returns(1);
        //    _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //    vstack.Border = _borderMock.Object;
        //    //act
        //    IScreenDisplay screenDisplay = vstack.GetDisplay(new Bound(3, 4), '*');
        //    //assert
        //    const string expected = "----\n" +
        //                            "-**-\n" +
        //                            "----";
        //    Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //}
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("____\n").Append("_  _\n").Append("____"));
        //            _borderMock.Setup(b => b.Thickness).Returns(1);
        //            _borderMock.Setup(b => b.BorderChar).Returns('_');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
        //            //assert
        //            const string expected = "____\n" +
        //                                    "_**_\n" +
        //                                    "____";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("iiii\n").Append("illi\n").Append("iiii"));
        //            _borderMock.Setup(b => b.Thickness).Returns(1);
        //            _borderMock.Setup(b => b.BorderChar).Returns('i');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
        //            //assert
        //            const string expected = "iiii\n" +
        //                                    "i**i\n" +
        //                                    "iiii";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("-----\n").Append("-   -\n").Append("-   -\n").Append("-   -\n").Append("-----"));
        //            _borderMock.Setup(b => b.Thickness).Returns(1);
        //            _borderMock.Setup(b => b.BorderChar).Returns('-');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(5, 5));
        //            //assert
        //            const string expected = "-----\n" +
        //                                    "-***-\n" +
        //                                    "-***-\n" +
        //                                    "-***-\n" +
        //                                    "-----";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //[Fact]
        //public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        //{
        //    //arrange
        //    _screenDisplayMock.Setup(s => s.DisplayString).Returns(
        //        new StringBuilder().Append("------\n")
        //                           .Append("-    -\n")
        //                           .Append("------"));
        //    _borderMock.Setup(b => b.Thickness).Returns(1);
        //    _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //    vstack.Border = _borderMock.Object;
        //    //act
        //    IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 6));
        //    //assert
        //    const string expected = "------\n" +
        //                            "-****-\n" +
        //                            "------";
        //    Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //}
        //[Fact]
        //public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness1()
        //{
        //    //arrange
        //    _screenDisplayMock.Setup(s => s.DisplayString).Returns(
        //        new StringBuilder().Append("-----\n")
        //                           .Append("-----\n")
        //                           .Append("-- --\n")
        //                           .Append("-----\n")
        //                           .Append("-----"));
        //    _borderMock.Setup(b => b.Thickness).Returns(2);
        //    _borderMock.Setup(b => b.BorderChar).Returns('-');
        //    _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //    vstack.Border = _borderMock.Object;
        //    //act
        //    IScreenDisplay screenDisplay = vstack.GetDisplay(new(5, 5));
        //    //assert
        //    const string expected = "-----\n" +
        //                            "-----\n" +
        //                            "--*--\n" +
        //                            "-----\n" +
        //                            "-----";
        //    Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //}
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness2()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(
        //                new StringBuilder().Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("--   --\n").
        //                                    Append("--   --\n").
        //                                    Append("-------\n").
        //                                    Append("-------"));
        //            _borderMock.Setup(b => b.Thickness).Returns(2);
        //            _borderMock.Setup(b => b.BorderChar).Returns('-');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(6, 7));
        //            //assert
        //            const string expected = "-------\n" +
        //                                    "-------\n" +
        //                                    "--***--\n" +
        //                                    "--***--\n" +
        //                                    "-------\n" +
        //                                    "-------";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness3()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(
        //                new StringBuilder().Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("--- ---\n").
        //                                    Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("-------"));
        //            _borderMock.Setup(b => b.Thickness).Returns(3);
        //            _borderMock.Setup(b => b.BorderChar).Returns('-');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(7, 7));
        //            //assert
        //            const string expected = "-------\n" +
        //                                    "-------\n" +
        //                                    "-------\n" +
        //                                    "---*---\n" +
        //                                    "-------\n" +
        //                                    "-------\n" +
        //                                    "-------";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //        [Fact]
        //        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border_thickness4()
        //        {
        //            //arrange
        //            _screenDisplayMock.Setup(s => s.DisplayString).Returns(
        //                new StringBuilder().Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("--- ---\n").
        //                                    Append("-------\n").
        //                                    Append("-------\n").
        //                                    Append("-------"));
        //            _borderMock.Setup(b => b.Thickness).Returns(3);
        //            _borderMock.Setup(b => b.BorderChar).Returns('-');
        //            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
        //            vstack.Border = _borderMock.Object;
        //            //act
        //            IScreenDisplay screenDisplay = vstack.GetDisplay(new(7, 7));
        //            //assert
        //            const string expected = "-------\n" +
        //                                    "-------\n" +
        //                                    "-------\n" +
        //                                    "---*---\n" +
        //                                    "-------\n" +
        //                                    "-------\n" +
        //                                    "-------";
        //            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        //        }
        //[Fact]
        //public void TestBoundedVStack()
        //{
        //    var output = new StringBuilder();
        //    using (var writer = new StringWriter(output))
        //    {
        //        var ui = new GiftUI(new Bound(20, 60));
        //        var vstack = new VStackBuilder().WithFraction(0.3)).Build();
        //        var label1 = new LabelBuilder().BuildImplicit();
        //        ui.SetChild(vstack);
        //        vstack.AddChild(label1);
        //        TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

        //        var expectedBuilder = new StringBuilder();
        //        string expected = "";
        //        var actual = renderedText.ToString().Split('\n');
        //        for (int i = 0; i < ui.Bound.Height; i++)
        //        {
        //            expectedBuilder.Clear();
        //            expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
        //            expected = expectedBuilder.ToString();
        //            if (i == 0)
        //            {
        //                expected = TestHelper.Replace(expected, "Hello", 0);
        //            }
        //            Assert.Equal(expected, actual[i]);
        //        }
        //    }
        //}
    }
}
