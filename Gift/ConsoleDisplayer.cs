using Gift.UI.Display;

namespace Gift
{
    public class ConsoleDisplayer : IDisplayer
    {
        public ConsoleDisplayer()
        {
        }

        public void display(IScreenDisplay screenDisplay)
        {
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(screenDisplay.DisplayString);
        }
    }
}