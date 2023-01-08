using Gift.UI.MetaData;

namespace Gift.UI.Strategy
{
    /// <summary>
    /// Behavior when position is explicitly given
    /// </summary>
    public class ExplicitDisposition : DispositionStrategy
    {
        /// <summary>
        /// position where to render element
        /// </summary>
        public Position Position { get ; private set ; }

        /// <summary>
        /// create behavior when relative position is given
        /// </summary>
        /// <param name="position"></param>
        public ExplicitDisposition(Position position)
        {
            Position = position;
        }
    }
}