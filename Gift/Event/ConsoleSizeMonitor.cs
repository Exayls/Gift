using System;

namespace Gift.Event
{
    class ConsoleSizeMonitor : IMonitor
    {
        public event EventHandler? SizeChanged;

        private int ConsoleWidth;
        private int ConsoleHeight;

        public ConsoleSizeMonitor()
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                ConsoleWidth = Console.WindowWidth;
                ConsoleHeight = Console.WindowHeight;
            }
        }

        private void OnSizeChanged(int consoleHeight, int consoleWidth)
        {
            EventArgs eventArgs = new ConsoleSizeEventArgs(consoleHeight, consoleWidth);
            SizeChanged?.Invoke(this, eventArgs);
        }

        public void Check()
        {
            if (Console.WindowWidth != ConsoleWidth || Console.WindowHeight != ConsoleHeight)
            {
                ConsoleWidth = Console.WindowWidth;
                ConsoleHeight = Console.WindowHeight;
                OnSizeChanged(ConsoleHeight, ConsoleWidth);
            }
        }
    }
}