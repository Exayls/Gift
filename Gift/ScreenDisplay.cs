using Gift.UI.MetaData;
using System.Text;

namespace Gift
{
    public class ScreenDisplay
    {
        public Bound TotalBound { get; }
        public StringBuilder DisplayString { get; }

        public ScreenDisplay()
        {
            DisplayString = new StringBuilder();
        }

        public ScreenDisplay(Bound bound)
        {
            DisplayString = new StringBuilder();
            TotalBound = bound;
        }
    }
}