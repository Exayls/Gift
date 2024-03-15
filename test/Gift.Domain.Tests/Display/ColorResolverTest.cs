using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
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
        public void Given_container_is_selected_GetFrontColor_should_be_selected()
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
    }
}
