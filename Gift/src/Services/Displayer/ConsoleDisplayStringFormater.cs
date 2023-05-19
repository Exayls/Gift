using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.MetaData;

namespace Gift.src.Services.Displayer
{
    public class ConsoleDisplayStringFormater : IConsoleDisplayStringFormater
    {
        public string CreateDislayString(IScreenDisplay screenDisplay)
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

                    displayString += displayMap[i, j];

                    oldFrontColor = frontColorMap[i, j];
                    oldBackColor = backColorMap[i, j];
                }
            }

            return displayString;
        }
    }
}