using Gift.src.Services.FileParser;
using Gift.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGift.Test
{
    public class XmlFileParserTests
    {
        private XmlFileParser xmlParser;

        public XmlFileParserTests()
        {
            xmlParser = new XmlFileParser();
        }

        [Fact]
        public void ParseUIFile_ValidFilePath_ReturnsGiftUI()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";

            // Act
            IGiftUI result = xmlParser.ParseUIFile(filePath);

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
