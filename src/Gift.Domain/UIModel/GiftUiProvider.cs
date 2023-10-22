using Gift.Domain.Builders;

namespace Gift.Domain.UIModel
{
    public class GiftUiProvider : IGiftUiProvider
    {
        private GiftUI? _ui;
        public GiftUI Ui
        {
            get
            {
                return _ui ?? new GiftUIBuilder().Build();
            }
            set
            {
                _ui = value;
            }
        }

    }
}
