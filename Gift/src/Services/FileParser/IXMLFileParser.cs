﻿using Gift.UI;

namespace Gift.src.Services.FileParser
{
    public interface IXMLFileParser
    {
        GiftUI ParseUIFile(string filePath);
    }
}
