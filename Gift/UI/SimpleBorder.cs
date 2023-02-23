using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class SimpleBorder : IBorder
    {
        public char BorderChar { get; }
        public int Thickness { get; }


        public SimpleBorder(int thickness, char borderChar)
        {
            BorderChar = borderChar;
            Thickness = thickness;
        }

        public IScreenDisplay GetDisplay(Bound bound)
        {
            IScreenDisplay screenDisplay = new ScreenDisplay(bound);
            AddBorder(screenDisplay);
            return screenDisplay;
        }

        private void AddBorder(IScreenDisplay screenDisplay)
        {
        }
    }
}