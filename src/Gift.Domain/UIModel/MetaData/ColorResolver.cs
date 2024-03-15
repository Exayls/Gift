using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.UIModel.MetaData
{
    public class ColorResolver : IColorResolver
    {
        private readonly IRepository _repository;

        public ColorResolver(IRepository repository)
        {
            _repository = repository;
        }

        public Color GetFrontColor(UIElement element, IConfiguration configuration)
        {
            Color frontColor = element.FrontColor == Color.Default ? configuration.DefaultFrontColor : element.FrontColor;
            if (IsSelectedContainer(element))
            {
                frontColor = configuration.SelectedContainerFrontColor == Color.Default
                                 ? frontColor
                                 : configuration.SelectedContainerFrontColor;
            }
            return frontColor;
        }

        public Color GetBackColor(UIElement element, IConfiguration configuration)
        {
            Color backColor = element.BackColor == Color.Default ? configuration.DefaultBackColor : element.BackColor;
            if (IsSelectedContainer(element))
            {
                backColor = configuration.SelectedContainerBackColor == Color.Default
                                ? backColor
                                : configuration.SelectedContainerBackColor;
            }
            return backColor;
        }

        private bool IsSelectedContainer(UIElement element)
        {
            if (element is Container)
            {
                return _repository.GetSelectedContainer() == element;
            }
			return false;
        }
    }
}
