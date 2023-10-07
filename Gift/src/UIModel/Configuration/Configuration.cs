using Gift.UI.MetaData;

namespace Gift.UI.Conf
{
    public class Configuration : IConfiguration
    {
        public Color DefaultFrontColor { get; }
        public Color DefaultBackColor { get; }

        public Color SelectedContainerFrontColor { get; }
        public Color SelectedContainerBackColor { get; }

        public Color SelectedElementFrontColor { get; }
        public Color SelectedElementBackColor { get; }
        public char FillingChar { get; }

        public Configuration(Color frontColor = Color.White,
                             Color backColor = Color.Black,
                             Color selectedElementFrontColor = Color.Default,
                             Color selectedElementBackColor = Color.Green,
                             Color selectedContainerFrontColor = Color.Green,
                             Color selectedContainerBackColor = Color.Default,
							 char fillingChar = ' ')
        {
            DefaultBackColor = backColor;
            DefaultFrontColor = frontColor;
            SelectedContainerFrontColor = selectedContainerFrontColor;
            SelectedContainerBackColor = selectedContainerBackColor;
            SelectedElementFrontColor = selectedElementFrontColor;
            SelectedElementBackColor = selectedElementBackColor;
			FillingChar = fillingChar;
        }
    }
}
