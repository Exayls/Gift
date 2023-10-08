﻿namespace Gift.Domain.UIModel
{
    public class GiftUiProvider : IGiftUiProvider
    {
        private GiftUI? _ui;
        public GiftUI Ui
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