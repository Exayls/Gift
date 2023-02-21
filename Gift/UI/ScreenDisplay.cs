using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public class ScreenDisplay
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
            FillDisplayString(emptychar);
        }

        private void FillDisplayString(char emptychar)
        {
            DisplayString.Append(new string(emptychar, TotalBound.Width));
            for (int i = 1; i < TotalBound.Height; i++)
            {
                DisplayString.Append('\n');
                DisplayString.Append(new string(emptychar, TotalBound.Width));
            }
        }

        public void AddDisplay(ScreenDisplay display, Position globalPosition)
        {
            for (int i = 0; i < display.TotalBound.Height; i++)
            {
                bool ShouldAddLine = globalPosition.x <= TotalBound.Width
                    && globalPosition.y + i + 1 <= TotalBound.Height
                    && globalPosition.y + i >= 0;
                if (ShouldAddLine)
                {
                    AddOneLineToDisplay(display, globalPosition, i);
                }
            }
        }

        private void AddOneLineToDisplay(ScreenDisplay display, Position globalPosition, int i)
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

        private string GetLine(int i)
        {
            return DisplayString.ToString().Split('\n')[i];
        }

        internal void AddString(string display, Position position)
        {
            Helper.Replace(DisplayString, display, position.y * (TotalBound.Width + 1) + position.x);
        }
    }
}