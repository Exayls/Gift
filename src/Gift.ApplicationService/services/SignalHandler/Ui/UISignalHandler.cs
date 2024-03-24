using System;
using Gift.Domain.UIModel.MetaData;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.Monitor.Console;

namespace Gift.ApplicationService.Services.SignalHandler.Ui
{
    public class UISignalHandler : IUISignalHandler
    {
        private IDisplayService _displayService;


        public UISignalHandler(IDisplayService displayManager)
        {
            _displayService = displayManager;
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
            _displayService.ScrollUp();
            _displayService.UpdateDisplay();
        }

        private void ScrollDown()
        {
            _displayService.ScrollDown();
            _displayService.UpdateDisplay();
        }

        private void NextElement()
        {
            _displayService.NextElementInSelectedContainer();
            _displayService.UpdateDisplay();
        }

        private void PreviousElement()
        {
            _displayService.PreviousElementInSelectedContainer();
            _displayService.UpdateDisplay();
        }

        private void NextContainer()
        {
            _displayService.NextContainer();
            _displayService.UpdateDisplay();
        }

        private void PreviousContainer()
        {
            _displayService.PreviousContainer();
            _displayService.UpdateDisplay();
        }

        private void OnSizeChanged(EventArgs e)
        {
            if (e is ConsoleSizeEventArgs)
            {
                ConsoleSizeEventArgs eventArgs = (ConsoleSizeEventArgs)e;
                _displayService.Resize(new Size(eventArgs.ConsoleHeight, eventArgs.ConsoleWidth));
                _displayService.UpdateDisplay();
            }
        }
    }
}
