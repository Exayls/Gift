using System;

namespace Gift.ApplicationService.Services.SignalHandler
{
    public class Signal : ISignal
    {
        public EventArgs EventArgs { get; private set; }

        public string Name { get; }

        public Signal(string name, EventArgs eventArgs)
        {
            Name = name;
            EventArgs = eventArgs;
        }
    }
}
