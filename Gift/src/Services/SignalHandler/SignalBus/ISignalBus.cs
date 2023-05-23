using Gift.SignalHandler;

namespace Gift.Bus
{
    public interface ISignalBus
    {
        void PushSignal(ISignal signal);
        Task PushSignalAsync(Signal signal);
        void Subscribe(ISignalHandler signalmanager);
    }
}