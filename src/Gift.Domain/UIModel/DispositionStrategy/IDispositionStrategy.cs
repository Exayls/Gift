using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.DispositionStrategy
{
    /// <summary>
    /// Define behavior for disposition
    /// </summary>
    public interface IDispositionStrategy
    {
        public Position Position { get; }
    }
}
