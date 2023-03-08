using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Display
{
    public class ScreenDisplay : IScreenDisplay
    {
        public Bound TotalBound { get; }
        public StringBuilder DisplayString { get; }


        public ScreenDisplay(Bound bound) : this(bound, GiftBase.FILLINGCHAR)
        {
        }
        public ScreenDisplay(Bound bound, char emptychar)
        {
            DisplayString = new StringBuilder();
            TotalBound = bound;
            FillDisplay(emptychar);
        }

        public ScreenDisplay(string display) : this(new(1, display.Length), GiftBase.FILLINGCHAR)
        {
            DisplayString.Clear().Append(display);
        }

        private void FillDisplay(char emptychar)
        {
            DisplayString.Append(new string(emptychar, TotalBound.Width));
            for (int i = 1; i < TotalBound.Height; i++)
            {
                DisplayString.Append('\n');
                DisplayString.Append(new string(emptychar, TotalBound.Width));
            }
        }

        public void AddDisplay(IScreenDisplay display, Position globalPosition)
        {
            for (int i = 0; i < display.TotalBound.Height; i++)
            {
                bool ShouldAddLine = globalPosition.x <= TotalBound.Width
                    && globalPosition.y + i + 1 <= TotalBound.Height
                    && globalPosition.y + i >= 0;
                if (ShouldAddLine)
                {
                    AddLineToDisplay(display, globalPosition, i);
                }
            }
        }

        private void AddLineToDisplay(IScreenDisplay display, Position globalPosition, int i)
        {
            int indexLineToReplace = (globalPosition.y + i) * (TotalBound.Width + 1) + globalPosition.x;
            int lenghtToReplace = display.TotalBound.Width;
            if (globalPosition.x + display.TotalBound.Width > TotalBound.Width)
            {
                lenghtToReplace = TotalBound.Width - globalPosition.x;
            }
            else if (globalPosition.x < 0)
            {
                indexLineToReplace = (globalPosition.y + i) * (TotalBound.Width + 1);
                lenghtToReplace = display.TotalBound.Width + globalPosition.x;
            }
            DisplayString.Remove(indexLineToReplace, lenghtToReplace);

            string lineToInsert = display.GetLine(i);
            string stringToInsert = lineToInsert.Substring(0, lenghtToReplace);
            DisplayString.Insert(indexLineToReplace, stringToInsert);
        }

        public string GetLine(int i)
        {
            return DisplayString.ToString().Split('\n')[i];
        }

        public void AddString(string display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display);
            AddDisplay(tmpScreen, position);
        }

        public void AddChar(char display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display.ToString());
            AddDisplay(tmpScreen, position);
        }
    }
}