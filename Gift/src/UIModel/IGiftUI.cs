﻿using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public interface IGiftUI : IContainer
    {
        List<IContainer> SelectableContainers { get; set; }
        void AddChild(IUIElement UIElement);
        void PreviousElementInSelectedContainer();
        void NextElementInSelectedContainer();
        void Resize(Bound bound);
        void NextContainer();
        void PreviousContainer();
    }
}