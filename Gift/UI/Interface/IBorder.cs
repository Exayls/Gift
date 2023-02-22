namespace Gift.UI.Interface
{
    public interface IBorder
    {
        int Thickness { get; }
        public IScreenDisplay GetDisplay();
    }
}