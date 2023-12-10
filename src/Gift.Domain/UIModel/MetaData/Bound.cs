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
        public bool Equals(Bound bound)
        {
            if (!(bound is Bound))
            {
                return false;
            }
			if (!(Width == bound.Width) || !(Height == Height))
			{
				return false;
			}
            return true;
        }
    }
}
