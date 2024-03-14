using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.ServiceContracts
{
    public interface IColorResolver
    {
        Color GetBackColor(Container container, IConfiguration configuration);
        Color GetFrontColor(Container container, IConfiguration configuration);
    }
}
