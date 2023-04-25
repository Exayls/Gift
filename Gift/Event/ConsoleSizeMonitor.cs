using System;
class ConsoleSizeMonitor
{
    public event EventHandler? SizeChanged;

    private int ConsoleWidth;
    private int ConsoleHeight;
    private Timer timer;

    public ConsoleSizeMonitor()
    {
        if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
        {
            ConsoleWidth = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;

        }
        timer = new Timer(CheckWindowSize, null, 0, 100);
    }

    private void CheckWindowSize(object? state)
    {
        if (Console.WindowWidth != ConsoleWidth || Console.WindowHeight != ConsoleHeight)
        {
            ConsoleWidth = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;

            OnSizeChanged(ConsoleHeight, ConsoleWidth);
        }
    }

    private void OnSizeChanged(int consoleHeight, int consoleWidth)
    {
        EventArgs eventArgs = new ConsoleSizeEventArgs(consoleHeight, consoleWidth);
        SizeChanged?.Invoke(this, eventArgs);
    }

}