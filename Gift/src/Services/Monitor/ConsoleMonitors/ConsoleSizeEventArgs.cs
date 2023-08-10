using System;

namespace Gift.src.Services.Monitor.ConsoleMonitors
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
