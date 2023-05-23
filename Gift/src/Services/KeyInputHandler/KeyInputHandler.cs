﻿using Gift.SignalHandler;
using Gift.src.Services.SignalHandler.Bus;

namespace Gift.KeyInput
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
            await Task.Yield();
            while (true)
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
}