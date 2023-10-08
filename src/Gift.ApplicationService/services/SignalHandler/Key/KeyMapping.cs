using System;

namespace Gift.src.Services.SignalHandler.Key
{
    public class KeyMapping : IKeyMapping
    {
        public (ConsoleKey key, ConsoleModifiers modifiers) KeyInfo { get; }
        public string SignalName { get; }
        public KeyMapping((ConsoleKey key, ConsoleModifiers modifiers) keyInfo, string signalName)
        {
            KeyInfo = keyInfo;
            SignalName = signalName;
        }
    }
}
