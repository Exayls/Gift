using System;
using System.IO;
using Gift.Domain.Builders;
using Gift.Domain.Builders.Mappers;
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

        public XmlFileParserTests(ITestOutputHelper output)
        {
            var mockColorMapper = new ColorMapper();
            var mockBorderMapper = new BorderMapper();
            var mockBoundMapper = new BoundMapper();
            var elementRegister = new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(output),
                                                        mockBorderMapper, mockColorMapper, mockBoundMapper);

            xmlParser = new XmlFileParser(elementRegister, LoggerHelper.GetLogger<IXMLFileParser>(output));
            _output = output;
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
                            .WithBound(new Bound(5, 8))
                            .WithForegroundColor(Color.Blue)
                            .WithUnSelectableElement(new LabelBuilder()
                                                         .WithText("Hello")
                                                         .WithBorder(new DetailedBorder(1, BorderOption.Simple))
                                                         .Build())
                            .WithUnSelectableElement(new LabelBuilder().WithText("World").Build())
                            .Build())
                    .Build();
            logger.LogTrace(expected.Childs.Count.ToString());
            Log(logger, expected);
            Log(logger, (GiftUI)result);
            Assert.True(expected.Equals(result));
        }

        private static void Log(ILogger<IXMLFileParser> logger, GiftUI element)
        {
            logger.LogTrace("{}", element.Childs[0].BackColor);
        }
    }
}
