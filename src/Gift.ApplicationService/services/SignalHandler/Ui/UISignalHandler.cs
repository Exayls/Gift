using System;
using Gift.SignalHandler;
using Gift.src.Services.Monitor.ConsoleMonitors;
using Gift.UI.Service;
using Gift.Domain.UIModel.MetaData;

namespace Gift.src.Services.SignalHandler.Ui
{
    public class UISignalHandler : IUISignalHandler
    {
        private IDisplayService _displayManager;


        public UISignalHandler(IDisplayService displayManager)
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
                case "Ui.ScrollUp":
                    ScrollUp();
                    break;
                case "Ui.ScrollDown":
                    ScrollDown();
                    break;
                default:
                    break;
            }
        }

        private void ScrollUp()
        {
            _displayManager.ScrollUp();
            _displayManager.UpdateDisplay();
        }

        private void ScrollDown()
        {
            _displayManager.ScrollDown();
            _displayManager.UpdateDisplay();
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
