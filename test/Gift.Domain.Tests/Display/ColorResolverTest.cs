using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using Xunit;

namespace Gift.Domain.Tests.Display
{
    public class ColorResolverTest
    {
        private readonly IRepository _repository;

        public ColorResolverTest()
        {
            _repository = Mock.Of<IRepository>();
        }

        [Fact]
        public void Given_container_is_selected_GetFrontColor_should_be_Green()
        {
            // Arrange
            Container selectedContainer = new VStackBuilder().Build();
            Mock.Get<IRepository>(_repository)
                .Setup(r => r.GetSelectedContainer())
                .Returns(selectedContainer);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetFrontColor(selectedContainer, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.Green, color);
        }

        [Fact]
        public void Given_container_is_not_selected_GetFrontColor_should_be_White()
        {
            // Arrange
            Container container = new VStackBuilder().Build();
            Mock.Get<IRepository>(_repository)
                .Setup(r => r.GetSelectedContainer())
                .Returns<Container?>(null);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetFrontColor(container, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.White, color);
        }

        [Fact]
        public void GetBackColor_should_be_Transparent()
        {
            // Arrange
            Container container = new VStackBuilder().Build();
            Mock.Get<IRepository>(_repository)
                .Setup(r => r.GetSelectedContainer())
                .Returns<Container?>(null);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetBackColor(container, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.Transparent, color);
        }

        [Fact]
        public void Given_element_is_not_selected_GetBackColor_should_be_Transparent()
        {
            // Arrange
            Label label = new LabelBuilder().Build();
            Mock.Get<IRepository>(_repository);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetBackColor(label, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.Transparent, color);
        }

        [Fact]
        public void Given_element_is_not_selected_GetFrontColor_should_be_White()
        {
            // Arrange
            Label label = new LabelBuilder().Build();
            Mock.Get<IRepository>(_repository);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetFrontColor(label, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.White, color);
        }

        [Fact]
        public void Given_element_is_selected_GetBackColor_should_be_Green()
        {
            // Arrange
			
            Label label = new LabelBuilder().Build();
			VStack vstack = new VStackBuilder()
				.WithSelectableElement(label)
				.Build();
            Mock.Get<IRepository>(_repository)
				.Setup(r => r.GetSelectedContainer()).Returns<Container?>(null);
            var colorResolver = new ColorResolver(_repository);

            // Act
            Color color = colorResolver.GetBackColor(label, new DefaultConfiguration());

            // Assert
            Assert.Equal(Color.Green, color);
        }
    }
}
