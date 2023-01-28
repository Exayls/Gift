﻿using Gift;
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
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));
                var vstack = new VStackBuilder().Build();
                ui.SetChild(vstack);
                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
                for (int i = 0; i < ui.Bound.Height; i++)
                {
                    expectedBuilder.Clear();
                    expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, ui.Bound.Width));
                    expected = expectedBuilder.ToString();
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
        [Fact]
        public void TestVStackWithLabelImplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));
                var vstack = new VStackBuilder().Build();
                var label = new LabelBuilder().BuildImplicit();
                ui.SetChild(vstack);
                vstack.AddChild(label);
                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
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
        }
        [Fact]
        public void TestVStackWithLabelExplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));
                var vstack = new VStackBuilder().Build();
                var label = new LabelBuilder().Build();
                ui.SetChild(vstack);
                vstack.AddChild(label);
                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
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
        }
        [Fact]
        public void TestVStackWith2LabelsImplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
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
                var actual = renderedText.ToString().Split('\n');
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
        }
        [Fact]
        public void TestVStackWith3LabelsImplicit()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
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
                var actual = renderedText.ToString().Split('\n');
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
        }
        [Fact]
        public void TestVStackWithExplicitLabel()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
                var ui = new GiftUI(new Bound(20, 60));
                var vstack = new VStackBuilder().Build();
                var label1 = new LabelBuilder().BuildImplicit();
                var label2 = new LabelBuilder().WithText("test").WithPosition(new Position(4,8)).Build();
                var label3 = new LabelBuilder().WithText("label numero 3.").BuildImplicit();
                ui.SetChild(vstack);
                vstack.AddChild(label1);
                vstack.AddChild(label2);
                vstack.AddChild(label3);
                TextWriter renderedText = new Renderer().GetRenderedBuffer(ui);

                var expectedBuilder = new StringBuilder();
                string expected = "";
                var actual = renderedText.ToString().Split('\n');
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
        }
        [Fact]
        public void TestVStackWithTooMuchElement()
        {
            var output = new StringBuilder();
            using (var writer = new StringWriter(output))
            {
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
                var actual = renderedText.ToString().Split('\n');
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
                    if (i == 4)
                    {
                        expected = TestHelper.Replace(expected, "label numero 5.", 0);
                    }
                    Assert.Equal(expected, actual[i]);
                }
            }
        }
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
