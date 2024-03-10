using Gift.Domain.Builders.UIModel;

namespace Gift.Domain.UIModel
{
    public class GiftUiProvider : IGiftUiProvider
    {
        private GiftUI? _ui;
        public GiftUI Ui
        {
            get
            {
                return _ui ?? (GiftUI)new GiftUIBuilder().Build();
            }
            set
            {
                _ui = value;
            }
        }

    }
}
