namespace Gift.src.Services.Monitor.Console
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