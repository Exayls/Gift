using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Conf
{
    public class DefaultConfiguration : IConfiguration
    {
        public Color DefaultFrontColor => Color.White;
        public Color DefaultBackColor => Color.Transparent;

        public Color SelectedElementFrontColor => Color.White;
        public Color SelectedElementBackColor => Color.Green;

        public Color SelectedContainerFrontColor => Color.Green;
        public Color SelectedContainerBackColor => Color.Transparent;

        public char FillingChar => '*';
    }
}
