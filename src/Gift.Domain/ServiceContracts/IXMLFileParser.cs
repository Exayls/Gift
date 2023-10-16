using Gift.Domain.UIModel;

namespace Gift.Domain.ServiceContracts
{
    public interface IXMLFileParser
    {
        GiftUI ParseUIFile(string filePath);
    }
}
