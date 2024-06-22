namespace Gift.Domain.UIModel.MetaData
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int y, int x)
        {
            X = x;
            Y = y;
        }
    }
}
