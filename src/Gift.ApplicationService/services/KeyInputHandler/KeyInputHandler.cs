using System;
using System.Threading.Tasks;
using Gift.ApplicationService.services.SignalHandler;
using Gift.ApplicationService.services.SignalHandler.Bus;

namespace Gift.ApplicationService.services.KeyInputHandler
{
    public class KeyInputHandler : IKeyInputHandler
    {
        private ISignalBus _signalBus;
        public KeyInputHandler(ISignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public async void StartCheckUserInput()
        {
            while (true)
            {
                await Task.Run(() => CheckUserInput());
            }
        }

        private void CheckUserInput()
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
