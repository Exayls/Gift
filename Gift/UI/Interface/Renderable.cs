using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Interface
{
    public interface Renderable
    {
        int Height { get; }
        int Width { get; }

        IScreenDisplay GetDisplay(Bound bound);
        Position GetGlobalPosition(Context context);
        bool IsFixed();
    }
}