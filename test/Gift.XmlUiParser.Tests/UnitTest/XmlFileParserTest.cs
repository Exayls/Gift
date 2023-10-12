using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.XmlUiParser.FileParser;
using System;
using System.IO;
using Xunit;

namespace Gift.XmlUiParser.Tests.UnitTest
{
    public class XmlFileParserTests
    {
        private XmlFileParser xmlParser;
        private IUIElementRegister elementRegister;

        public XmlFileParserTests()
        {
            elementRegister = new UIElementRegister();
            elementRegister.Register("GiftUI", typeof(GiftUI));
            elementRegister.Register("Label", typeof(Label));
            elementRegister.Register("VStack", typeof(VStack));
            xmlParser = new XmlFileParser(elementRegister);
        }

        [Fact]
        public void ParseUIFile_ValidFilePath_ReturnsGiftUI()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";

            // Act
            GiftUI result = xmlParser.ParseUIFile(filePath);

            // Assert
            Assert.NotNull(result);
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
    }
}
