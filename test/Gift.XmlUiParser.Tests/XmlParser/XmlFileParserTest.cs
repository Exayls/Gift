using System;
using System.IO;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.XmlUiParser.FileParser;
using Gift.XmlUiParser.Tests.Helper;
using Moq;
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
            var mockColorMapper = Mock.Of<IColorMapper>();
            var mockBorderMapper = Mock.Of<IBorderMapper>();
            var elementRegister = new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(output), mockBorderMapper, mockColorMapper);

            xmlParser = new XmlFileParser(elementRegister,
                              LoggerHelper.GetLogger<IXMLFileParser>(output));
            _output = output;
        }

        [Fact]
        public void ParseUIFile_ValidFilePath_ReturnsGiftUI()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFileUsingBuilders(filePath);
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
            Assert.Throws<DirectoryNotFoundException>(() => xmlParser.ParseUIFileUsingBuilders(filePath));
        }

        [Fact]
        public void ParseUIFile_UnsupportedComponent_ThrowsNotSupportedException()
        {
            // Arrange
            string filePath = "ressources/xml/not_supported.xml";
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => xmlParser.ParseUIFileUsingBuilders(filePath));
        }

        [Fact]
        public void When_Border_is_set_should_create_element_with_border()
        {
            // Arrange
            string filePath = "ressources/xml/vstack_border.xml";
            // Act
            UIElement result = xmlParser.ParseUIFileUsingBuilders(filePath);
            // Assert
            Assert.IsType<VStack>(result);
            Assert.Equal(5, result.Height);
            Assert.Equal(8, result.Width);
        }


        [Fact]
        public void When_ParseUIFile_is_called_should_create_all_objects_hierarchically()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFileUsingBuilders(filePath);
            // Assert
            Assert.IsType<GiftUI>(result);
            Assert.Collection(((GiftUI)result).Childs,
                    (child) =>
                 {
                     Assert.IsType<VStack>(child);

                     Assert.Collection(((VStack)child).Childs,
                             (c) =>
                          {
                              Assert.IsType<Label>(c);
                          }, (c) =>
                          {
                              Assert.IsType<Label>(c);
                          });
                 });
        }
    }
}
