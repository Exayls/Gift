﻿using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public interface IRenderable
    {
        int Height { get; }
        int Width { get; }

        IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration);
        IScreenDisplay GetDisplayBorder(Bound bounds, IConfiguration configuration);
        Position GetRelativePosition(Context context);
        bool IsFixed();
    }
}