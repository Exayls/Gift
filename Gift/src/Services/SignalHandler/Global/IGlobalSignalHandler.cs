using Gift.SignalHandler;

namespace Gift.src.Services.SignalHandler.Global
{
    public interface IGlobalSignalHandler : ISignalHandler
    {
        TaskCompletionSource<bool> Completion { get; set; }
    }
}