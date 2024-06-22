using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;

namespace Gift.Domain.UIModel.Border
{
    public class NoBorder : IBorder
    {
        public int Thickness { get; }
        public char BorderChar { get; }

        public NoBorder()
        {
            BorderChar = ' ';
            Thickness = 0;
        }

        public bool IsSimilarTo(IBorder border)
        {
            if (!(border is NoBorder))
                return false;
            return true;
        }

        public IScreenDisplay GetDisplay(ScreenDisplayBuilder screenDisplayBuilder)
        {
            return screenDisplayBuilder.Build();
        }
    }
}
