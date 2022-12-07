namespace Gift.View
{
    public class View : UIElement
    {
        public UIElement UIElement { get; set; }
        public View()
        {
        }
        public View(UIElement uIElement)
        {
            UIElement = uIElement;
        }

        public void Render()
        {
            Console.WriteLine("render");
        }
    }
}