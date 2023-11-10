using System;
using System.IO;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.XmlUiParser.FileParser;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class XmlFileParserTests
    {

        private XmlFileParser xmlParser;

        public XmlFileParserTests(ITestOutputHelper output)
        {
            var elementRegister = new UIElementRegister();

			var loggerFactory = new LoggerFactory(new[]{new XunitLoggerProvider(output)});
			var logger = loggerFactory.CreateLogger<IXMLFileParser>();

            xmlParser = new XmlFileParser(elementRegister, logger);
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
