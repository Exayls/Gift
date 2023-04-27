using Gift.SignalHandler;

namespace Gift.Bus
{
    public interface ISignalBus
    {
        void PushSignal(ISignal signal);
        void Subscribe(ISignalHandler signalmanager);
    }
}