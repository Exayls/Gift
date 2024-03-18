
namespace Gift.Domain.UIModel.MetaData
{
    public class Context
    {
        public Context(Position position, Size bounds)
        {
            Position = position;
            Bounds = bounds;
        }

        public Position Position { get; private set; }
        public Size Bounds { get; private set; }

    }
}
