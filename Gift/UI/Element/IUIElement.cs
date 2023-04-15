﻿using Gift.UI.Border;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IUIElement : IRenderable
    {
        IBorder Border { get; set; }
        bool IsSelectedElement { get; set; }
        bool IsInSelectedContainer { get; set; }
    }
}