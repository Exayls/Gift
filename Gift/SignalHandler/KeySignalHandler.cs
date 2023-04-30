using Gift.Builders;
using Gift.Bus;
using Gift.KeyInput;
using Gift.UI;
using Gift.UI.DisplayManager;

namespace Gift.SignalHandler
{
    internal class KeySignalHandler : ISignalHandler
    {
        private ISignalBus _bus;

        public KeySignalHandler(ISignalBus bus)
        {
            _bus = bus;
        }

        public void HandleSignal(ISignal signal)
        {
            if (signal.EventArgs is KeyEventArgs)
            {
                KeyEventArgs eventsArgs = (KeyEventArgs)signal.EventArgs;
                if (eventsArgs.KeyValue == ConsoleKey.T)
                {
                    _bus.PushSignal(new Signal("Ui.NextElementInSelectedContainer", EventArgs.Empty));
                }
                if (eventsArgs.KeyValue == ConsoleKey.S)
                {
                    _bus.PushSignal(new Signal("Ui.PreviousElementInSelectedContainer", EventArgs.Empty));
                }
            }
        }
    }
}