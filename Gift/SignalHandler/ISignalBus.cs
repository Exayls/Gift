
namespace Gift.SignalHandler
{
    public interface ISignalBus
    {
        void PushSignal(ISignal signal);
        void Subscribe(ISignalHandler signalmanager);
    }
}