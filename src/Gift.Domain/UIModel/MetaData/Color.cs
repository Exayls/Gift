namespace Gift.Domain.UIModel.MetaData
{
    public enum Color
    {
        Black,
        Red,
        Green,
        Yellow,
        Blue,
        Magenta,
        Cyan,
        White,
        Default,
		Transparent
    }

    public static class ConsoleColorExExtensions
    {
        public static string GetForegroundEscapeCode(this Color color)
        {
            if (color == Color.Transparent) return "\u001b[0m";
            if (color == Color.Default) return "";
            return $"\u001b[{(int)color + 30}m";
        }

        public static string GetBackgroundEscapeCode(this Color color)
        {
            if (color == Color.Transparent) return "\u001b[0m";
            if (color == Color.Default) return "";
            return $"\u001b[{(int)color + 40}m";
        }
    }
}
