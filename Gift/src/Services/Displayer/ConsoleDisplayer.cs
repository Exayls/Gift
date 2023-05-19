using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Displayer
{
    public class ConsoleDisplayer : IDisplayer
    {
        private IConsoleDisplayStringFormater _formater;

        public ConsoleDisplayer(IConsoleDisplayStringFormater formater)
        {
            _formater = formater;
        }

        public void display(IScreenDisplay screenDisplay)
        {
            string displayString = _formater.CreateDislayString(screenDisplay);

            Console.SetCursorPosition(0, 0);
            Console.Out.Write(displayString);
        }

    }
}