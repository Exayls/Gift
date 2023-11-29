using Gift.Domain.UIModel.Element;

namespace Gift.Domain.ServiceContracts
{
    public interface IXMLFileParser
    {
        UIElement ParseUIFileUsingBuilders(string filePath);

    }
}
