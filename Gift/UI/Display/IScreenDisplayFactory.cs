﻿using Gift.UI.MetaData;

namespace Gift.UI.Display
{
    public interface IScreenDisplayFactory
    {
        IScreenDisplay Create(Bound boundEmptyVStack, Color frontColor = Color.White, Color backColor = Color.Black, char fillingChar = GiftBase.FILLINGCHAR);
    }
}