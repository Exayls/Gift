using System;

namespace Gift.SignalHandler
{
    internal class Signal : ISignal
    {
        private EventArgs eventArgs;

        public string Name { get; }

        public Signal(string name, EventArgs eventArgs) 
        {
            Name = name;
            this.eventArgs = eventArgs;
        }


    }
}