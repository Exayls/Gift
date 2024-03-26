using System;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Display;
using Microsoft.Extensions.Logging;

namespace Gift.Displayer.Displayer
{
    public class ConsoleDisplayer : IDisplayer
    {
        private readonly IConsoleDisplayStringFormater _formater;
        private readonly ILogger<IDisplayer> _logger;

        public ConsoleDisplayer(IConsoleDisplayStringFormater formater, ILogger<IDisplayer> logger)
        {
            _formater = formater;
			_logger = logger;
        }

        public void Display(IScreenDisplay screenDisplay)
        {
            string displayString = _formater.CreateDislayString(screenDisplay);
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(displayString);
        }
    }
}
