using System;
using System.IO;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.XmlUiParser.FileParser;
using Gift.TestsHelper.Tests.Helper;
using Xunit;
using Xunit.Abstractions;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class XmlFileParserTests
    {

        private readonly XmlFileParser xmlParser;
        private readonly ITestOutputHelper _output;


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
            var logger = LoggerHelper.GetLogger<IDisplayer>(_output);

        }

        [Fact]
        public void ParseUIFile_ValidFilePath_ReturnsGiftUI()
        {
            // Arrange
            string filePath = "resources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<VStack>(result);
        }

        [Fact]
        public void ParseUIFile_InvalidFilePath_ThrowsException()
        {
            // Arrange
            string filePath = "resources/invalid/invalid.xml";
            // Act & Assert
            Assert.Throws<DirectoryNotFoundException>(() => xmlParser.ParseUIFile(filePath));
        }

        [Fact]
        public void ParseUIFile_UnsupportedComponent_ThrowsNotSupportedException()
        {
            // Arrange
            string filePath = "resources/xml/not_supported.xml";
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => xmlParser.ParseUIFile(filePath));
        }

        [Fact]
        public void When_ParseUIFile_is_called_should_create_all_objects_hierarchically()
        {

            var logger = LoggerHelper.GetLogger<IXMLFileParser>(_output);
            // Arrange
            string filePath = "resources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            var expected =
                new VStackBuilder()
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
            string filePath = "resources/xml/selectable.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            var expected =
                new VStackBuilder()
                    .WithUnSelectableElement(
                        new VStackBuilder()
                            .IsSelectableContainer(true)
                            .Build())
                    .Build();
            Assert.True(expected.IsSimilarTo(result));
        }

        [Fact]
        public void Given_xml_with_id_element_should_have_id()
        {

            string filePath = "resources/xml/id.xml";
            // Act
            UIElement result = xmlParser.ParseUIFile(filePath);
            // Assert
            Assert.True(result.Id == "bbb");
        }

    }
}
