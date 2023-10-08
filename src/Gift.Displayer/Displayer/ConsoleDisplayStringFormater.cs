using System;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Displayer.Displayer
{
    public class ConsoleDisplayStringFormater : IConsoleDisplayStringFormater
    {
        public string CreateDislayString(IScreenDisplay screenDisplay)
        {
            string displayString = "";

            char[,] displayMap = screenDisplay.DisplayMap;
            Color[,] frontColorMap = screenDisplay.FrontColorMap;
            Color[,] backColorMap = screenDisplay.BackColorMap;
            if (displayMap.GetLength(0) != frontColorMap.GetLength(0) || displayMap.GetLength(0) != backColorMap.GetLength(0) || displayMap.GetLength(1) != frontColorMap.GetLength(1) || displayMap.GetLength(1) != backColorMap.GetLength(1))
            {
                throw new RankException($"All maps are not of the same dimension in {screenDisplay}");
            }

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
