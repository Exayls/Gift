using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Displayer
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
            Color[,] frontColorMap = screenDisplay.FrontColorMap;
            Color[,] backColorMap = screenDisplay.BackColorMap;

            Color? oldFrontColor = null;
            Color? oldBackColor = null;
            for (int i = 0; i < displayMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayMap.GetLength(1); j++)
                {
                    Color currentFrontColor = frontColorMap[i, j];
                    Color currentBackColor = backColorMap[i, j];

                    if (oldFrontColor != currentFrontColor)
                        displayString += currentFrontColor.GetForegroundEscapeCode();

                    if (oldBackColor != currentBackColor)
                        displayString += currentBackColor.GetBackgroundEscapeCode();

                    displayString += displayMap[i,j];

                    oldFrontColor = frontColorMap[i, j];
                    oldBackColor = backColorMap[i, j];
                }
                    displayString += "\n";
            }

            Console.SetCursorPosition(0, 0);
            Console.Out.Write(displayString);
        }
    }
}