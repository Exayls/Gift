﻿namespace Gift.SignalHandler.KeyInput
{
    public interface IKeyMapping
    {
        (ConsoleKey key, ConsoleModifiers modifiers) KeyInfo { get; }
        string SignalName { get; }
    }
}