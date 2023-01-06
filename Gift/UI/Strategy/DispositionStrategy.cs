using Gift.UI.MetaData;

namespace Gift.UI
{
    /// <summary>
    /// Define behavior for disposition
    /// </summary>
    public interface DispositionStrategy
    {
        /// <summary>
        /// position where to render element
        /// </summary>
        public Position Position { get; }
    }
}