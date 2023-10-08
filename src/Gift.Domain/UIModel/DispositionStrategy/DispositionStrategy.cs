using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.DispositionStrategy
{
    /// <summary>
    /// Define behavior for disposition
    /// </summary>
    public interface DispositionStrategy
    {
        public Position Position { get; }
    }
}
