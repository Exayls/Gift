using System;

namespace Gift.KeyInput
{
    class KeyEventArgs : EventArgs
    {
        public ConsoleKey KeyValue { get; }
        public ConsoleModifiers Modifier { get; }

        public KeyEventArgs(ConsoleKey keyValue, ConsoleModifiers modifier)
        {
            KeyValue = keyValue;
            Modifier = modifier;
        }

    }
}
