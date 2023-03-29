﻿using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Display
{
    public interface IScreenDisplay
    {
        StringBuilder DisplayString { get; }
        Bound TotalBound { get; }
        Color BackColor { get; set; }
        Color FrontColor { get; set; }

        void AddDisplay(IScreenDisplay display, Position globalPosition);
        void AddString(string display, Position position);
        void AddChar(char display, Position position);
        string GetLine(int i);
    }
}