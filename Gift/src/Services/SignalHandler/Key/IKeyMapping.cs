namespace Gift.src.Services.SignalHandler.Key
{
    public interface IKeyMapping
    {
        (ConsoleKey key, ConsoleModifiers modifiers) KeyInfo { get; }
        string SignalName { get; }
    }
}