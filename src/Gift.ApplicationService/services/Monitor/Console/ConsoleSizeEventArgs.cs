using System;

namespace Gift.ApplicationService.Services.Monitor.Console
{
    public class ConsoleSizeEventArgs : EventArgs
    {
        public int ConsoleHeight { get; }
        public int ConsoleWidth { get; }

        public ConsoleSizeEventArgs(int consoleHeight, int consoleWidth)
        {
            ConsoleHeight = consoleHeight;
            ConsoleWidth = consoleWidth;
        }
    }
}
