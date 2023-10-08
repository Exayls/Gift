﻿using Gift.ApplicationService.services.SignalHandler;
using Gift.ApplicationService.services.SignalHandler.Bus;
using System;

namespace Gift.ApplicationService.services.Monitor.ConsoleMonitors
{
    public class ConsoleSizeMonitor : IConsoleSizeMonitor
    {
        private int ConsoleWidth;
        private int ConsoleHeight;
        private ISignalBus _signalBus;

        public ConsoleSizeMonitor(ISignalBus signalBus)
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                ConsoleWidth = Console.WindowWidth;
                ConsoleHeight = Console.WindowHeight;
            }
            _signalBus = signalBus;
        }

        public void Check()
        {
            if (Console.WindowWidth != ConsoleWidth || Console.WindowHeight != ConsoleHeight)
            {
                ConsoleWidth = Console.WindowWidth;
                ConsoleHeight = Console.WindowHeight;

                EventArgs eventArgs = new ConsoleSizeEventArgs(ConsoleHeight, ConsoleWidth);
                ISignal signal = new Signal("Console.Resize", eventArgs);
                _signalBus.PushSignal(signal);
            }
        }
    }
}