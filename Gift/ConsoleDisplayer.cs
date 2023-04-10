using Gift.UI.Display;
using System.Text;

namespace Gift
{
    public class ConsoleDisplayer : IDisplayer
    {
        public ConsoleDisplayer()
        {
        }

        public void display(IScreenDisplay screenDisplay)
        {
            string displayString = "";
            char[,] displayMap = screenDisplay.DisplayMap;
            for (int i = 0; i < displayMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayMap.GetLength(1); j++)
                {
                    displayString += displayMap[i, j];
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(displayString);
        }
    }
}