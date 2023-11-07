
using System;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.XmlUiParser.FileParser;
using Moq;
using Xunit;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class UIElementRegisterTest
    {

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
        public void When_retrieving_text_method_should_return_WithText_method()
        {
            //Arrange
            Mock<IUIElementBuilder> labelBuilderMock = new Mock<IUIElementBuilder>();

            var elementRegister = GetElementRegister();
            var labelBuilderType = elementRegister.GetBuilder("label");
            var labelBuilder = labelBuilderType.GetConstructors()[0].Invoke(new object[] { });

            elementRegister.Register<IUIElementBuilder>("UIElement");
            elementRegister.Register<IUIElementBuilder>("text", (b, t) => { return b; });

            // Act
            var method = elementRegister.GetMethod<IUIElementBuilder>("text");
            // Assert
            Assert.Equal(labelBuilderMock.Object, method(labelBuilderMock.Object, "hello"));
        }


        private static object ConstructBuilder(Type labelBuilderType)
        {
            return labelBuilderType.GetConstructors()[0].Invoke(new object[] { });
        }

        private static IUIElementRegister GetElementRegister()
        {
            return new UIElementRegister();
        }
    }
}