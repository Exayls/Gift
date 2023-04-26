using Gift.UI;

namespace Gift.SignalHandler
{
    public interface ISignalManager
    {
        void HandleSignal(ISignal signal, GiftUI ui);
        void HandleSignal(ISignal signal);
    }
}