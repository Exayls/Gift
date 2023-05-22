using Gift.UI;

namespace Gift.src.UIModel
{
    public class GiftUiProvider : IGiftUiProvider
    {
        private IGiftUI? _ui;
        public IGiftUI Ui
        {
            get
            {
                return _ui ?? new GiftUI();
            }
            set
            {
                _ui = value;
            }
        }

    }
}