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
                if (globalPosition.x > TotalBound.Width)
                {
                    return;
                }
                else if (globalPosition.x + display.TotalBound.Width > TotalBound.Width)
                {
                    int indexLineToReplace = (globalPosition.y + i) * (TotalBound.Width + 1) + globalPosition.x;
                    int lenghtToReplace = TotalBound.Width - globalPosition.x;
                    DisplayString.Remove(indexLineToReplace, lenghtToReplace).Insert(indexLineToReplace, display.GetLine(i).Substring(0, lenghtToReplace));
                }
                else if (globalPosition.x < 0)
                {
                    int indexLineToReplace = (globalPosition.y + i) * (TotalBound.Width + 1);
                    int lenghtToReplace = display.TotalBound.Width + globalPosition.x;
                    DisplayString.Remove(indexLineToReplace, lenghtToReplace).Insert(indexLineToReplace, display.GetLine(i).Substring(0, lenghtToReplace));
                }
                else
                {
                    int indexLineToReplace = (globalPosition.y + i) * (TotalBound.Width + 1) + globalPosition.x;
                    DisplayString.Remove(indexLineToReplace, display.TotalBound.Width).Insert(indexLineToReplace, display.GetLine(i));
                }
            }
        }

        private string GetLine(int i)
        {
            return DisplayString.ToString().Substring((i * (TotalBound.Width + 1)), TotalBound.Width - i);
        }

        internal void AddString(string display, Position position)
        {
            Helper.Replace(DisplayString, display, position.y * (TotalBound.Width + 1) + position.x);
        }
    }
}