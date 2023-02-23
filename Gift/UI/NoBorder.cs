using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class NoBorder : IBorder
    {
        public int Thickness { get; }
        public char BorderChar { get; }

        public NoBorder()
        {
            BorderChar = ' ';
            Thickness = 0;
        }

        public IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(bound);
        }
    }
}