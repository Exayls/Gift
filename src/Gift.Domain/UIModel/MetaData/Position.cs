namespace Gift.Domain.UIModel.MetaData
{
    public class Position
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int y, int x)
        {
            this.x = x;
            this.y = y;
        }
    }
}
