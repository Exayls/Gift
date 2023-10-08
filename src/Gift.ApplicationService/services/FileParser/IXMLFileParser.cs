using Gift.Domain.UIModel;

namespace Gift.ApplicationService.services.FileParser
{
    public interface IXMLFileParser
    {
        GiftUI ParseUIFile(string filePath);
    }
}
