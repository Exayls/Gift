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
            _displayManager.Ui.NextElementInSelectedContainer();
            _displayManager.UpdateDisplay();
        }

        private void PreviousElement()
        {
            _displayManager.Ui.PreviousElementInSelectedContainer();
            _displayManager.UpdateDisplay();
        }

        private void NextContainer()
        {
            _displayManager.Ui.NextContainer();
            _displayManager.UpdateDisplay();
        }

        private void PreviousContainer()
        {
            _displayManager.Ui.PreviousContainer();
            _displayManager.UpdateDisplay();
        }

        private void OnSizeChanged(EventArgs e)
        {
            if (e is ConsoleSizeEventArgs)
            {
                ConsoleSizeEventArgs eventArgs = (ConsoleSizeEventArgs)e;
                _displayManager.Ui.Resize(new Bound(eventArgs.ConsoleHeight, eventArgs.ConsoleWidth));
                _displayManager.UpdateDisplay();
            }
        }
    }
}