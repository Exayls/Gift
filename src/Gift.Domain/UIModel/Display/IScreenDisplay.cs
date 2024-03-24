using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using System.Text;

namespace Gift.Domain.UIModel.Display
{
    public interface IScreenDisplay
    {
        StringBuilder DisplayString { get; }
        Size TotalBound { get; }
        Color[,] FrontColorMap { get; }
        Color[,] BackColorMap { get; }
        char[,] DisplayMap { get; }

        void AddDisplay(IScreenDisplay display, Position globalPosition);
        void AddBorder(int thickness, BorderOption borderChars);
        void AddString(string display, Position position);
        void AddChar(char display, Position position);
        string GetLine(int i);
    }
}
