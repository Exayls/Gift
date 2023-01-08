using Gift.UI.Interface;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI
{
    public class GiftUI : Container
    {

        public GiftUI(Renderer renderer, Bound bound) : base(bound)
        {
            Renderer = renderer;
        }
        public GiftUI(Renderer renderer) 
        {
            Renderer = renderer;
        }

        public void SetChild(UIElement UIElement)
        {
            foreach (UIElement r in Childs)
            {
                Childs.Remove(r);
            }
            Childs.Add(UIElement);

            UIElement.setContext(new Position(0, 0), Bound);
            UIElement.Renderer = Renderer;
        }

        public void Render()
        {
            Renderer?.Render(this);
        }
    }
}
