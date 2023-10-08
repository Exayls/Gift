using System;
using Gift.Domain.UIModel.Display;

namespace Gift.ApplicationService.services.Displayer
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
