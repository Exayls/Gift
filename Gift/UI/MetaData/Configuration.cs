namespace Gift.UI.MetaData
{
    public class Configuration : IConfiguration
    {
        public Color DefaultFrontColor { get; }

        public Color DefaultBackColor { get; }

        public Configuration(Color frontColor, Color backColor)
        {
            DefaultBackColor = backColor;
            DefaultFrontColor = frontColor;
        }
    }
}