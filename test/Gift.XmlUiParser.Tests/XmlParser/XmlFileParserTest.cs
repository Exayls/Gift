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
            var mockBoundMapper = Mock.Of<IBoundMapper>();
            var elementRegister = new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(output), mockBorderMapper, mockColorMapper, mockBoundMapper);

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
        public void When_ParseUIFile_is_called_should_create_all_objects_hierarchically()
        {
            // Arrange
            string filePath = "ressources/xml/valid_xml.xml";
            // Act
            UIElement result = xmlParser.ParseUIFileUsingBuilders(filePath);
            // Assert
            var expected = new GiftUIBuilder()
             .WithUnSelectableElement(
                        new VStackBuilder()
                        .WithBound(new Bound(5, 8))
                        .WithForegroundColor(Color.Blue)
                        .WithUnSelectableElement(
                            new LabelBuilder()
                            .WithText("Hello")
                            .WithBorder(new DetailedBorder(1, BorderOption.Simple))
                            .Build()
                         )
                        .WithUnSelectableElement(
                            new LabelBuilder()
                            .WithText("World")
                            .Build()
                         )
                        .Build()
                        )
             .Build();
            Assert.True(expected.Equals(result));
        }
    }
}
