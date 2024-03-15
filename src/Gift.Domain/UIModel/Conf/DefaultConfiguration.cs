using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Conf
{
    public class DefaultConfiguration : IConfiguration
    {
        public Color DefaultFrontColor { get { return Color.White; } }
        public Color DefaultBackColor { get { return Color.Transparent; } }

        public Color SelectedElementFrontColor { get { return Color.White; } }
        public Color SelectedElementBackColor { get { return Color.Green; } }

        public Color SelectedContainerFrontColor { get { return Color.Green; } }
        public Color SelectedContainerBackColor { get { return Color.Transparent; } }

        public char FillingChar { get { return '*'; } }

    }
}
