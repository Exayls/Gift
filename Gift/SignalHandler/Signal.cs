using System;

namespace Gift.SignalHandler
{
    internal class Signal : ISignal
    {
        public EventArgs EventArgs { get; private set; }

        public string Name { get; }

        public Signal(string name, EventArgs eventArgs)
        {
            Name = name;
            this.EventArgs = eventArgs;
        }


    }
}