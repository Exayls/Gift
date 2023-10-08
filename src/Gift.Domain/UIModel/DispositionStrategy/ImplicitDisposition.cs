using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.DispositionStrategy
{
    public class ImplicitDisposition : IDispositionStrategy
    {
        public ImplicitDisposition()
        {
            Position = new Position(0, 0);
        }

        public Position Position { get; }
    }
}
