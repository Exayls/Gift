using Gift.UI;

namespace Gift.src.Services.FileParser
{
    public interface IXMLFileParser
    {
        IGiftUI ParseUIFile(string filePath);
    }
}