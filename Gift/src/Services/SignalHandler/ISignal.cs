namespace Gift.SignalHandler
{
    public interface ISignal
    {
        string Name { get; }
        EventArgs EventArgs { get; }
    }
}