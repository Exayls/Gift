using Gift.Domain.UIModel;

namespace Gift.ApplicationService.Services.FileParser
{
    public interface IXMLFileParser
    {
        GiftUI ParseUIFile(string filePath);
    }
}
