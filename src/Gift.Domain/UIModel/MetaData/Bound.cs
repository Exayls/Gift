namespace Gift.Domain.UIModel.MetaData
{
    public class Bound
    {
        public int Width { get; }
        public int Height { get; }
        public Bound(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }
    }
}
