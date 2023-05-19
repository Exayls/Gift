using Gift.UI.Border;
using Gift.UI.Configuration;
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

        private IContainer? _selectedContainer;
        public IContainer? SelectedContainer
        {
            get
            {
                return _selectedContainer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (!SelectableContainers.Contains(value))
                {
                    throw new InvalidOperationException("trying to select a container outside of the selectable range");
                }
                RemoveOldSelectedContainer();
                SetNewSelectedContainer(value);
            }
        }

        private void SetNewSelectedContainer(IContainer selected)
        {
            _selectedContainer = selected;
            selected.IsSelectedContainer = true;
            foreach (IUIElement element in selected.SelectableElements)
            {
                element.IsInSelectedContainer = true;
            }
        }

        private void RemoveOldSelectedContainer()
        {
            foreach (IContainer container in SelectableContainers)
            {
                container.IsSelectedContainer = false;
                foreach (IUIElement element in container.SelectableElements)
                {
                    element.IsInSelectedContainer = false;
                }
            }
        }

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

        public void AddChild(UIElement UIElement)
        {
            Childs.Add(UIElement);
        }

        public override Context GetContextRelativeRenderable(IRenderable renderable, Context context)
        {
            return context;
        }

        public override bool IsFixed()
        {
            return false;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, IConfiguration configuration)
        {
            return _screenDisplayFactory.Create(Bound, FrontColor ?? configuration.DefaultFrontColor, BackColor ?? configuration.DefaultBackColor, GiftBase.FILLINGCHAR);
        }

        public override Position GetRelativePosition(Context context)
        {
            return context.Position;
        }

        public override Position GetGlobalPosition(Context context)
        {
            return context.Position;
        }

        public void Resize(Bound bound)
        {
            this.Bound = bound;
        }

        public void NextElementInSelectedContainer()
        {
            if (SelectedContainer != null)
            {
                SelectedContainer.NextElement();
            }
        }
        public void PreviousElementInSelectedContainer()
        {
            if (SelectedContainer != null)
            {
                SelectedContainer.PreviousElement();
            }
        }
        public void NextContainer()
        {
            if (SelectedContainer != null)
            {
                SelectedContainer = SelectableContainers[(SelectableContainers.IndexOf(SelectedContainer) + 1) % SelectableContainers.Count];
            }
        }
        public void PreviousContainer()
        {
            if (SelectedContainer != null)
            {
                SelectedContainer = SelectableContainers[(SelectableContainers.IndexOf(SelectedContainer) - 1 + SelectableContainers.Count) % SelectableContainers.Count];
            }
        }
    }
}
