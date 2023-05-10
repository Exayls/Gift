using Gift.UI;

namespace Gift.SignalHandler
{
    public interface ISignalHandler
    {
        void HandleSignal(ISignal signal);
    }
}