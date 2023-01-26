using Gift.UI.MetaData;

namespace Gift.UI.Strategy
{
    /// <summary>
    /// Behavior when position is explicitly given
    /// </summary>
    public class ExplicitDisposition : DispositionStrategy
    {
        public Position Position { get ; private set ; }

        public ExplicitDisposition(Position position)
        {
            Position = position;
        }
    }
}