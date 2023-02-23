using Gift.UI.MetaData;

namespace Gift.UI.Interface
{
    public interface IBorder
    {
        int Thickness { get; }
        char BorderChar { get; }

        public IScreenDisplay GetDisplay(Bound bound);
    }
}