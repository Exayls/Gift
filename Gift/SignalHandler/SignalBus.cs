using Gift.Event;

namespace Gift.SignalHandler
{
    public class SignalBus : ISignalBus
    {
        private IList<ISignalManager> subscribers;
        public SignalBus()
        {
            subscribers = new List<ISignalManager>();
        }

        public void PushSignal(ISignal signal)
        {
            foreach (ISignalManager subscriber in subscribers)
            {
                subscriber.HandleSignal(signal);
            }
        }
        public void Subscribe(ISignalManager subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}