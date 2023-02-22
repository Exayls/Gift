using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Interface
{
    public interface IScreenDisplay
    {
        StringBuilder DisplayString { get; }
        Bound TotalBound { get; }

        void AddDisplay(IScreenDisplay display, Position globalPosition);
        void AddString(string display, Position position);
        string GetLine(int i);
    }
}