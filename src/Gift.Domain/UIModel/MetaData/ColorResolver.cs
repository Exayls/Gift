using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.UIModel.MetaData
{
    public class ColorResolver : IColorResolver
    {
        private readonly IRepository _repository;

        public ColorResolver(IRepository repository){
			_repository = repository;
		}

        public Color GetBackColor(Container container, IConfiguration configuration)
        {
            Color frontColor = container.FrontColor == Color.Default ? configuration.DefaultFrontColor : container.FrontColor;
            if (IsSelectedContainer(container))
            {
                frontColor = configuration.SelectedContainerFrontColor == Color.Default
                                 ? frontColor
                                 : configuration.SelectedContainerFrontColor;
            }
            return frontColor;
        }

        public Color GetFrontColor(Container container, IConfiguration configuration)
        {
            Color backColor = container.BackColor == Color.Default ? configuration.DefaultBackColor : container.BackColor;
            if (IsSelectedContainer(container))
            {
                backColor = configuration.SelectedContainerBackColor == Color.Default
                                ? backColor
                                : configuration.SelectedContainerBackColor;
            }
            return backColor;
        }

        private bool IsSelectedContainer(Container container)
        {
			return _repository.GetSelectedContainer() == container;
        }
    }
}
