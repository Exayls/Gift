using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.ServiceContracts
{
    public interface IColorResolver
    {
        Color GetBackColor(UIElement element, IConfiguration configuration);
        Color GetFrontColor(UIElement element, IConfiguration configuration);
    }
}
