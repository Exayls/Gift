using Gift.UI.MetaData;

namespace Gift.UI
{
    public class ImplicitDisposition : DispositionStrategy
    {
        public ImplicitDisposition()
        {
            Position = new Position(0,0);
        }

        public Position Position { get; }
    }
}