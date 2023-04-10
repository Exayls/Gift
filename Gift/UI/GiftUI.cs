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

        public List<IContainer> SelectableContainers { get; set; }
        public IContainer? SelectedContainer { get; set; }

        public GiftUI(Bound bound, IBorder border) : base(new ScreenDisplayFactory(), bound, border)
        {
            SelectableContainers = new List<IContainer>();
        }
        public GiftUI(Bound bound) : this(bound, new NoBorder())
        {
        }
        public GiftUI() : base()
        {
            SelectableContainers = new List<IContainer>();
        }

        public void SetChild(UIElement UIElement)
        {
            Childs.Clear();
            Childs.Add(UIElement);
        }

        public override Context GetContextRelativeRenderable(IRenderable renderable, Context context)
        {
            return context;
        }

        public override Context GetContextRenderable(IRenderable renderable, Context context)
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
            return _screenDisplayFactory.Create(Bound);
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return _screenDisplayFactory.Create(Bound);
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound)
        {
            return _screenDisplayFactory.Create(Bound, FrontColor, BackColor, GiftBase.FILLINGCHAR);
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound)
        {
            return Border.GetDisplay(bound, FrontColor, BackColor);
        }

        public override Position GetRelativePosition(Context context)
        {
            return context.Position;
        }

        public override Position GetGlobalPosition(Context context)
        {
            return context.Position;
        }

    }
}
