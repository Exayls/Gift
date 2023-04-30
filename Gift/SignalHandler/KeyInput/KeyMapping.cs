namespace Gift.SignalHandler.KeyInput
{
    public class KeyMapping : IKeyMapping
    {
        public KeyMapping((ConsoleKey key, ConsoleModifiers modifiers) keyInfo, string signalName)
        {
            KeyInfo = keyInfo;
            SignalName = signalName;
        }

        public (ConsoleKey key, ConsoleModifiers modifiers) KeyInfo { get; }
        public string SignalName { get; }
    }
}