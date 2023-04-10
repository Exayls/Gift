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
            StringBuilder displayString = screenDisplay.DisplayString;
            char[,] displayMap = screenDisplay.DisplayMap;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < displayMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayMap.GetLength(1); j++)
                {
                    Console.Out.Write(displayMap[i,j]);
                }
            }
        }
    }
}