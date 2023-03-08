using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI
{
    public class GiftUI : Container, IGiftUI
    {
        public override int Height
        {
            get { return Bound.Height; }
        }
        public override int Width
        {
            get { return Bound.Width; }
        }

        public GiftUI(Bound bound, IBorder border) : base(bound, border)
        {
        }
        public GiftUI(Bound bound) : base(bound, new NoBorder())
        {
        }
        public GiftUI() : base()
        {
        }

        public void SetChild(UIElement UIElement)
        {
            Childs.Clear();
            Childs.Add(UIElement);

            UIElement.setContext(new Position(0, 0), Bound);
        }

        public override bool isVisible(Renderable renderable)//TODO
        {
            return true;
        }

        public override Context GetContextRenderable(Renderable renderable, Context context)
        {
            if (Childs.Contains(renderable))
            {
                return context;
            }
            else
            {
                throw new Exception($"{renderable} has no context in {this}");
            }
        }

        public override bool IsFixed()
        {
            return false;
        }

        public IScreenDisplay GetDisplay()
        {
            return new ScreenDisplay(Bound);
        }
        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(bound);
        }

        public override Position GetGlobalPosition(Context context)
        {
            return context.GlobalPosition;
        }
    }
}
