using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Conf
{
    public interface IConfiguration
    {
        public Color DefaultFrontColor { get; }
        public Color DefaultBackColor { get; }

        public Color SelectedElementFrontColor { get; }
        public Color SelectedElementBackColor { get; }
        public Color SelectedContainerFrontColor { get; }
        public Color SelectedContainerBackColor { get; }
        public char FillingChar { get; }
    }
}
