﻿using System;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Display;

namespace Gift.Displayer.Displayer
{
    public class ConsoleDisplayer : IDisplayer
    {
        private IConsoleDisplayStringFormater _formater;

        public ConsoleDisplayer(IConsoleDisplayStringFormater formater)
        {
            _formater = formater;
        }

        public void Display(IScreenDisplay screenDisplay)
        {
            string displayString = _formater.CreateDislayString(screenDisplay);

			Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(displayString);
        }
    }
}
