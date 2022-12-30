﻿using Gift.UI.Interface;
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

        public GiftUI(Renderer renderer, Bound? b = null ): base(renderer, b)
        {
        }

        public void setChild(UIElement UIElement)
        {
            foreach (Renderable r in this.RenderableChilds){
                this.RenderableChilds.Remove(r);
            }
            this.RenderableChilds.Add(UIElement);

            UIElement.setContext(new Position(0,0),Bound);
        }

        public override void Display(TextWriter output)
        {
        }
    }
}
