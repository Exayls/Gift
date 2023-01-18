using System.Text;

namespace Gift
{
    public class ScreenDisplay
    {
        public StringBuilder DisplayString { get; internal set; }
        public ScreenDisplay()
        {
            DisplayString = new StringBuilder();
        }

    }
}