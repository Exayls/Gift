using Gift.UI.MetaData;
using System.Text;

namespace Gift
{
    public class ScreenDisplay
    {
        public Bound TotalBound { get; set; }
        public StringBuilder DisplayString { get; internal set; }
        public ScreenDisplay()
        {
            DisplayString = new StringBuilder();
        }

    }
}