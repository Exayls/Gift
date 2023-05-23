using Gift.SignalHandler;
using Gift.src.Services.Monitor.Console;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.DisplayManager;
using Gift.UI.MetaData;

namespace Gift.src.Services.SignalHandler.Ui
{
    public class UISignalHandler : IUISignalHandler
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
                case "Ui.NextElementInSelectedContainer":
                    NextElement();
                    break;
                case "Ui.PreviousElementInSelectedContainer":
                    PreviousElement();
                    break;
                case "Ui.NextContainer":
                    NextContainer();
                    break;
                case "Ui.PreviousContainer":
                    PreviousContainer();
                    break;
                case "Console.Resize":
                    OnSizeChanged(signal.EventArgs);
                    break;
                default:
                    break;
            }
        }

        private void NextElement()
        {
            _displayManager.NextElementInSelectedContainer();
            _displayManager.UpdateDisplay();
        }

        private void PreviousElement()
        {
            _displayManager.PreviousElementInSelectedContainer();
            _displayManager.UpdateDisplay();
        }

        private void NextContainer()
        {
            _displayManager.NextContainer();
            _displayManager.UpdateDisplay();
        }

        private void PreviousContainer()
        {
            _displayManager.PreviousContainer();
            _displayManager.UpdateDisplay();
        }

        private void OnSizeChanged(EventArgs e)
        {
            if (e is ConsoleSizeEventArgs)
            {
                ConsoleSizeEventArgs eventArgs = (ConsoleSizeEventArgs)e;
                _displayManager.Resize(new Bound(eventArgs.ConsoleHeight, eventArgs.ConsoleWidth));
                _displayManager.UpdateDisplay();
            }
        }
    }
}