﻿using System;
using System.IO;
using Gift.Displayer.Displayer;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.XmlUiParser.FileParser;
using Gift.XmlUiParser.Tests.Helper;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class XmlFileParserTests
    {

        private XmlFileParser xmlParser;
        private readonly ITestOutputHelper _output;

        private readonly ConsoleDisplayer _displayer;

        public XmlFileParserTests(ITestOutputHelper output)
        {
            var mockColorMapper = new ColorMapper();
            var mockBorderMapper = new BorderMapper();
            var mockBoundMapper = new BoundMapper();
            var mockBoolMapper = new BoolMapper();
            var elementRegister = new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(output),
                                                        mockBorderMapper, mockColorMapper, mockBoundMapper, mockBoolMapper);

            xmlParser = new XmlFileParser(elementRegister, LoggerHelper.GetLogger<IXMLFileParser>(output));
            _output = output;

            _displayer = new ConsoleDisplayer(new ConsoleDisplayStringFormater());
        }

        [Fact]
        public void ParseUIFile_ValidFilePath_ReturnsGiftUI()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<GiftUI>(result);
        }

        [Fact]
        public void ParseUIFile_InvalidFilePath_ThrowsException()
        {
            // Arrange
            string filePath = "ressources/invalid/invalid.xml";
            // Act & Assert
            Assert.Throws<DirectoryNotFoundException>(() => xmlParser.ParseUIFile(filePath));
        }

        [Fact]
        public void ParseUIFile_UnsupportedComponent_ThrowsNotSupportedException()
        {
            // Arrange
            string filePath = "ressources/xml/not_supported.xml";
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => xmlParser.ParseUIFile(filePath));
        }

        [Fact]
        public void When_ParseUIFile_is_called_should_create_all_objects_hierarchically()
        {

            var logger = LoggerHelper.GetLogger<IXMLFileParser>(_output);
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            var expected =
                new GiftUIBuilder()
                    .WithUnSelectableElement(
                        new VStackBuilder()
                            .WithBound(new Size(5, 8))
                            .WithForegroundColor(Color.Blue)
                            .WithUnSelectableElement(new LabelBuilder()
                                                         .WithText("Hello")
                                                         .WithBorder(new DetailedBorder(1, BorderOption.Simple))
                                                         .Build())
                            .WithUnSelectableElement(new LabelBuilder().WithText("World").Build())
                            .Build())
                    .Build();
            Assert.True(expected.IsSimilarTo(result));
        }


        [Fact]
        public void Given_xml_with_container_is_selectable_when_parsing_should_create_selectable_container()
        {

            var logger = LoggerHelper.GetLogger<IXMLFileParser>(_output);
            // Arrange
            string filePath = "ressources/xml/selectable.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            var expected =
                new GiftUIBuilder()
                    .WithSelectableContainer(
                        new VStackBuilder()
                            .Build())
                    .Build();
            Assert.True(expected.IsSimilarTo(result));
        }

        private static void Log(ILogger<IXMLFileParser> logger, GiftUI element)
        {
            logger.LogTrace("{}", element.Childs[0].BackColor);
        }
    }
}
