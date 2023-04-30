using Gift.Builders;
using Gift.Bus;
using Gift.KeyInput;
using Gift.SignalHandler.KeyInput;
using Gift.UI;
using Gift.UI.DisplayManager;

namespace Gift.SignalHandler
{
    internal class KeySignalHandler : ISignalHandler
    {
        private ISignalBus _bus;
        private IKeyMapper _keyMapper;

        public KeySignalHandler(ISignalBus bus, IKeyMapper keyMapper)
        {
            _bus = bus;
            _keyMapper = keyMapper;
            
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
                if (eventsArgs.KeyValue == ConsoleKey.C)
                {
                    _bus.PushSignal(new Signal("Ui.NextContainer", EventArgs.Empty));
                }
                if (eventsArgs.KeyValue == ConsoleKey.R)
                {
                    _bus.PushSignal(new Signal("Ui.PreviousContainer", EventArgs.Empty));
                }
            }
        }
    }
}