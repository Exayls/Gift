using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.View;

namespace Gift
{
    public class GiftUI: Renderable
    {
        public UIElement View { get; set; }
        public Renderer Renderer { get; set; }
        public ICollection<Renderable> RenderableChilds { get; set; }

        public GiftUI(UIElement view, Renderer renderer)
        {
            View = view;
            Renderer = renderer;
        }

        public virtual void run()
        {

        }

        public void Render()
        {
            Renderer.Render(this);
        }

    }
}
