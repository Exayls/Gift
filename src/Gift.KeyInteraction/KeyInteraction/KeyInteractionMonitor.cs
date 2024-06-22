using System;
using Gift.ApplicationService.Services.Monitor.KeyInteraction;
using Gift.ApplicationService.Services.SignalHandler;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.Domain.ServiceContracts;

namespace Gift.KeyInteraction.KeyInteraction
{
    public class KeyInteractionMonitor : IKeyInteractionMonitor
    {
        private readonly ISignalBus _signalBus;
        public KeyInteractionMonitor(ISignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Check()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                ConsoleModifiers modifier = consoleKeyInfo.Modifiers;
                ConsoleKey keyValue = consoleKeyInfo.Key;
                KeyEventArgs keyEventArgs = new KeyEventArgs(keyValue, modifier);
                _signalBus.PushSignal(new Signal("KeyPressed", keyEventArgs));
            }
        }
    }
}
