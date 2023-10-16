using System.Collections.Generic;

namespace Gift.ApplicationService.Services.SignalHandler.Bus
{
    public class SignalBus : ISignalBus
    {
        private IList<ISignalHandlerService> subscribers;
        public SignalBus()
        {
            subscribers = new List<ISignalHandlerService>();
        }

        public void PushSignal(ISignal signal)
        {
            foreach (ISignalHandlerService subscriber in subscribers)
            {
                subscriber.HandleSignal(signal);
            }
        }

        public void Subscribe(ISignalHandlerService subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}
