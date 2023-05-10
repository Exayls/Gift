
namespace Gift.UI.MetaData
{
    public class Context
    {
        public Context(Position position, Bound bounds)
        {
            Position = position;
            Bounds = bounds;
        }

        public Position Position { get; private set; }
        public Bound Bounds { get; private set; }

    }
}
