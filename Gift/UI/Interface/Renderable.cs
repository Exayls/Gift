using System.Text;

namespace Gift.UI.Interface
{
    public interface Renderable
    {
        //void Display(TextWriter output);
        void Render( StringBuilder stringBuilder);
    }
}