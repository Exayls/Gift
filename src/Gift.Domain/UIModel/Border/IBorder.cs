using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;

namespace Gift.Domain.UIModel.Border
{
    public interface IBorder
    {
        int Thickness { get; }

        public IScreenDisplay GetDisplay(ScreenDisplayBuilder screenDisplayBuilder);
        public bool IsSimilarTo(IBorder border);
    }
}
