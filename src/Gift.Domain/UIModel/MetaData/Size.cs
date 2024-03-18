namespace Gift.Domain.UIModel.MetaData
{
    public class Size
    {
        public int Width { get; }
        public int Height { get; }
        public Size(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }
        public bool Equals(Size bound)
        {
            if (!(bound is Size))
            {
                return false;
            }
            if (!(Width == bound.Width) || !(Height == bound.Height))
            {
                return false;
            }
            return true;
        }
    }
}
