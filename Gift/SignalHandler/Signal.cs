using System;

namespace Gift.SignalHandler
{
    internal class Signal
    {
        private IList<IObserver<Signal>> observers;

        public string Name { get; }

        public Signal(string name)
        {
            Name = name;
            this.observers = new List<IObserver<Signal>>();
        }

        public void Trigger()
        {
            foreach (IObserver<Signal> observer in observers)
            {
                //observer.
            }
        }

    }
}