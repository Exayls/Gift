using Gift.UI.MetaData;

namespace Gift.UI.Configuration
{
    public class DefaultConfiguration : IConfiguration
    {
        public Color DefaultFrontColor { get { return Color.White; } }

        public Color DefaultBackColor { get { return Color.Black; } }


        public Color SelectedElementFrontColor { get { return Color.Default; } }
        public Color SelectedElementBackColor { get { return Color.Green; } }
        public Color SelectedContainerFrontColor { get { return Color.Green; } }
        public Color SelectedContainerBackColor { get { return Color.Default; } }

    }
}