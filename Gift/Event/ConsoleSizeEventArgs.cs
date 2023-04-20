internal class ConsoleSizeEventArgs : EventArgs
{
    private int consoleHeight;
    private int consoleWidth;

    public ConsoleSizeEventArgs(int consoleHeight, int consoleWidth)
    {
        this.consoleHeight = consoleHeight;
        this.consoleWidth = consoleWidth;
    }
}