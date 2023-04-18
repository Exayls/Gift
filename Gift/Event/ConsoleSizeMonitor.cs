using System;
class ConsoleSizeMonitor
{
    public event EventHandler? SizeChanged;

    private int ConsoleWidth;
    private int ConsoleHeight;
    private Timer timer;

    public ConsoleSizeMonitor()
    {
        ConsoleWidth = Console.WindowWidth;
        ConsoleHeight = Console.WindowHeight;

        timer = new Timer(CheckWindowSize, null, 0, 100);
    }

    private void CheckWindowSize(object? state)
    {
        if (Console.WindowWidth != ConsoleWidth || Console.WindowHeight != ConsoleHeight)
        {
            ConsoleWidth = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;

            OnSizeChanged();
        }
    }

    protected virtual void OnSizeChanged()
    {
        SizeChanged?.Invoke(this, EventArgs.Empty);
    }
}