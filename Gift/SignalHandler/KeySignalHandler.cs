using Gift.Builders;
using Gift.UI;
using Gift.UI.DisplayManager;

namespace Gift.SignalHandler
{
    internal class KeySignalHandler: ISignalHandler
    {
        private IDisplayManager _displayManager;

        public KeySignalHandler(IDisplayManager displayManager)
        {
            _displayManager = displayManager;
        }

        public void HandleSignal(ISignal signal)
        {
            if(signal.Name == "T")
            {
                _displayManager.Ui.NextElementInSelectedContainer();
            }
            if(signal.Name == "S")
            {
                _displayManager.Ui.PreviousElementInSelectedContainer();
            }
            _displayManager.Ui.AddChild(new LabelBuilder().WithPosition(new(30, 30)).WithText(signal.Name).Build());
            _displayManager.UpdateDisplay();
        }
    }
}