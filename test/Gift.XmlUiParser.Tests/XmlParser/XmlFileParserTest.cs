using System;
using System.IO;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.XmlUiParser.FileParser;
using Xunit;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class XmlFileParserTests
    {
        private XmlFileParser xmlParser;
        private IUIElementRegister elementRegister;

        public XmlFileParserTests()
        {
            elementRegister = new UIElementRegister();

            xmlParser = new XmlFileParser(elementRegister);
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
        public void ParseUIFile_With_Builder_register()
        {
            // Arrange
            elementRegister = new UIElementRegister();


            xmlParser = new XmlFileParser(elementRegister);

            string filePath = "ressources/xml/valid_xml.xml";

            // Act
            UIElement result = xmlParser.ParseUIFileUsingBuilders(filePath);

            // Assert
            Assert.NotNull(result);
        }

    }
}
