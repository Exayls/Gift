using Gift.Monitor;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.DisplayManager;
using Gift.UI.MetaData;

namespace Gift.SignalHandler
{
    public class UISignalHandler : ISignalHandler
    {
        private IDisplayManager _displayManager;


        public UISignalHandler(IDisplayManager displayManager)
        {
            _displayManager = displayManager;
        }

        public void HandleSignal(ISignal signal)
        {
            switch (signal.Name)
            {
                case "UI.NextElement":
                    _displayManager.Ui.NextElementInSelectedContainer();
                    break;
                case "Console.Resize":
                    OnSizeChanged(signal.EventArgs);
                    break;
                default:
                    break;
            }
        }
        private void OnSizeChanged(EventArgs e)
        {
            ConsoleSizeEventArgs eventArgs = (ConsoleSizeEventArgs)e;
            _displayManager.Ui.Resize(new Bound(eventArgs.ConsoleHeight, eventArgs.ConsoleWidth));
            _displayManager.UpdateDisplay();
        }
    }
}