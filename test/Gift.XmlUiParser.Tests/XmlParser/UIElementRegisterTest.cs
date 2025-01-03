
using System;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.XmlUiParser.FileParser;
using Gift.TestsHelper.Tests.Helper;
using Moq;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;

namespace Gift.XmlUiParser.Tests.XmlParser
{
    public class UIElementRegisterTest
    {
        private readonly ITestOutputHelper _output;

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
            var labelBuilder = (UIElementBuilder)labelBuilderType.GetConstructors()[0].Invoke([]);

            elementRegister.Register<UIElementBuilder>("UIElement");
            elementRegister.Register<UIElementBuilder>(typeof(UIElementBuilder), "test", (b, t) => { return b; });

            // Act
            var method = elementRegister.GetMethod<UIElementBuilder>("test");
            // Assert
            Assert.Equal(typeof(LabelBuilder), method(labelBuilder, "hello").GetType());
        }

        [Fact]
        public void When_retrieving_FillingChar_method_from_vstack_should_return_registered_method()
        {
            //Arrange

            var elementRegister = GetElementRegister();
            var vstackBuilderType = elementRegister.GetBuilder("vstack");
            var vstackBuilder = (VStackBuilder)vstackBuilderType.GetConstructors()[0].Invoke([]);

            // Act
            var method = elementRegister.GetMethod<VStackBuilder>("fillingchar");
            // Assert
            Assert.Equal(typeof(VStackBuilder), method(vstackBuilder, "a").GetType());
        }

        [Fact]
        public void When_retrieving_FillingChar_method_from_hstack_should_return_registered_method()
        {
            //Arrange

            var elementRegister = GetElementRegister();
            var vstackBuilderType = elementRegister.GetBuilder("hstack");
            var vstackBuilder = (HStackBuilder)vstackBuilderType.GetConstructors()[0].Invoke([]);

            // Act
            var method = elementRegister.GetMethod<HStackBuilder>("fillingchar");
            // Assert
            Assert.Equal(typeof(HStackBuilder), method(vstackBuilder, "a").GetType());
        }


        private static object ConstructBuilder(Type labelBuilderType)
        {
            return labelBuilderType.GetConstructors()[0].Invoke([]);
        }

        private UIElementRegister GetElementRegister()
        {
            var mockColorMapper = Mock.Of<IColorMapper>();
            var mockBorderMapper = Mock.Of<IBorderMapper>();
            var mockBoundMapper = Mock.Of<IBoundMapper>();
            var mockBoolMapper = Mock.Of<IBooleanMapper>();
            return new UIElementRegister(LoggerHelper.GetLogger<IUIElementRegister>(_output), mockBorderMapper, mockColorMapper, mockBoundMapper, mockBoolMapper);
        }
    }
}
