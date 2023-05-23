using Gift.Monitor;
using Gift.SignalHandler;

namespace Gift.Bus
{
    public class SignalBus : ISignalBus
    {
        private IList<ISignalHandler> subscribers;
        public SignalBus()
        {
            subscribers = new List<ISignalHandler>();
        }

        public void PushSignal(ISignal signal)
        {
            foreach (ISignalHandler subscriber in subscribers)
            {
                subscriber.HandleSignal(signal);
            }
        }

        public Task PushSignalAsync(Signal signal)
        {
            foreach (ISignalHandler subscriber in subscribers)
            {
                subscriber.HandleSignal(signal);
            }
            return Task.CompletedTask;
        }

        public void Subscribe(ISignalHandler subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}