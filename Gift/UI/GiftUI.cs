using Gift.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI
{
    public class GiftUI : UIElement
    {

        public GiftUI(Renderer renderer) 
        {
            this.Renderer = renderer;
        }

        public void setChild(UIElement UIElement)
        {
            foreach (Renderable r in this.RenderableChilds){
                this.RenderableChilds.Remove(r);
            }
            this.RenderableChilds.Add(UIElement);
        }

        public override void Display(TextWriter output)
        {
        }
    }
}
