namespace Gift.Event
{
    internal class ConsoleSizeEventArgs : EventArgs
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