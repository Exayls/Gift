using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.DispositionStrategy
{
    /// <summary>
    /// Behavior when position is explicitly given
    /// </summary>
    public class ExplicitDisposition : IDispositionStrategy
    {
        public Position Position { get; private set; }

        public ExplicitDisposition(Position position)
        {
            Position = position;
        }
    }
}
