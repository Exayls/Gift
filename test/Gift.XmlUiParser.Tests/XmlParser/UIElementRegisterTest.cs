
using System;
using Gift.Domain.Builders;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.ServiceContracts;
using Gift.XmlUiParser.FileParser;
using Gift.XmlUiParser.Tests.Helper;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class UIElementRegisterTest
    {
        private ITestOutputHelper _output;

        public UIElementRegisterTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void When_GetBuilder_label_should_return_LabelBuilder_Type()
        {
            //Arrange
            var elementRegister = GetElementRegister();
            // Act
            var labelBuilderType = elementRegister.GetBuilder("label");
            // Assert
            Assert.True(labelBuilderType.IsAssignableFrom(typeof(LabelBuilder)));
        }

        [Fact]
        public void When_constructing_label_builder_should_get_LabelBuilder()
        {
            //Arrange
            var elementRegister = GetElementRegister();
            var labelBuilderType = elementRegister.GetBuilder("label");
            // Act
            var labelBuilder = ConstructBuilder(labelBuilderType);
            // Assert
            Assert.IsType<LabelBuilder>(labelBuilder);
        }


        [Fact]
        public void When_retrieving_text_method_should_return_registered_method()
        {
            //Arrange

            var elementRegister = GetElementRegister();
            var labelBuilderType = elementRegister.GetBuilder("label");
            var labelBuilder = (IUIElementBuilder)labelBuilderType.GetConstructors()[0].Invoke(new object[] { });

            elementRegister.Register<IUIElementBuilder>("UIElement");
            elementRegister.Register<IUIElementBuilder>(typeof(IUIElementBuilder), "test", (b, t) => { return b; });

            // Act
            var method = elementRegister.GetMethod<IUIElementBuilder>("test");
            // Assert
            Assert.Equal(typeof(LabelBuilder), method(labelBuilder, "hello").GetType());
        }


        private static object ConstructBuilder(Type labelBuilderType)
        {
            return labelBuilderType.GetConstructors()[0].Invoke(new object[] { });
        }

        private IUIElementRegister GetElementRegister()
        {
            var mockColorMapper = Mock.Of<IColorMapper>();
            var mockBorderMapper = Mock.Of<IBorderMapper>();
            var mockBoundMapper = Mock.Of<IBoundMapper>();
            return new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(_output), mockBorderMapper, mockColorMapper, mockBoundMapper);
        }
    }
}
