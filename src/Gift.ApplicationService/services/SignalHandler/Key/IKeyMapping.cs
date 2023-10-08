using System;

namespace Gift.ApplicationService.services.SignalHandler.Key
{
    public interface IKeyMapping
    {
        (ConsoleKey key, ConsoleModifiers modifiers) KeyInfo { get; }
        string SignalName { get; }
    }
}
