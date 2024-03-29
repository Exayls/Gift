﻿using System;

namespace Gift.ApplicationService.Services.Monitor.KeyInteraction
{
    public class KeyEventArgs : EventArgs
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
