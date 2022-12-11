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
        public Renderer Renderer { get; set; }
        public ICollection<Renderable> RenderableChilds { get; private set; }

        public GiftUI(Renderer renderer)
        {
            Renderer = renderer;
            RenderableChilds = new List<Renderable>();
        }


        public void Render()
        {
            Renderer.Render(this);
        }

        public void display()
        {
            Console.Write("Hello");
        }
    }
}
