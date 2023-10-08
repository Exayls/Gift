using System.Collections.Generic;

namespace Gift.ApplicationService.services.SignalHandler.Bus
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

        public void Subscribe(ISignalHandler subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}
