using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gift.Domain.UIModel
{
    public class GiftUI : Container
    {

        public override int Height
        {
            get
            {
                return Size.Height;
            }
        }
        public override int Width
        {
            get
            {
                return Size.Width;
            }
        }

        public List<Container> SelectableContainers { get; set; }

        private Container? _selectedContainer;
        public Container? SelectedContainer
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

        public GiftUI(Size size, IBorder border, Color frontColor, Color backColor, bool isSelectableContainer)
            : base(new ScreenDisplayFactory(), size, border, frontColor, backColor, isSelectableContainer)
        {
            SelectableContainers = new List<Container>();
        }

        private void SetNewSelectedContainer(Container selected)
        {
            _selectedContainer = selected;
            selected.IsSelectedContainer = true;
            foreach (UIElement element in selected.SelectableElements)
            {
                element.IsInSelectedContainer = true;
            }
        }

        private void RemoveOldSelectedContainer()
        {
            foreach (Container container in SelectableContainers)
            {
                container.IsSelectedContainer = false;
                foreach (UIElement element in container.SelectableElements)
                {
                    element.IsInSelectedContainer = false;
                }
            }
        }

        public override Position GetContext(Renderable renderable, Position position)
        {
            return position;
        }

        public override bool IsFixed()
        {
            return false;
        }

        public override Position GetRelativePosition(Position position)
        {
            return position;
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
                SelectedContainer = SelectableContainers[(SelectableContainers.IndexOf(SelectedContainer) + 1) %
                                                         SelectableContainers.Count];
            }
        }

        public void PreviousContainer()
        {
            if (SelectedContainer != null)
            {
                SelectedContainer = SelectableContainers[(SelectableContainers.IndexOf(SelectedContainer) - 1 +
                                                          SelectableContainers.Count) %
                                                         SelectableContainers.Count];
            }
        }

        public override bool IsSimilarTo(UIElement uiElement)
        {
            if (!(uiElement is GiftUI))
                return false;
            var element = (GiftUI)uiElement;
            if (SelectableContainers.Count != element.SelectableContainers.Count)
                return false;
            foreach ((Container element1,
                      Container element2) elementTuple in SelectableContainers.Zip(element.SelectableContainers))
            {
                if (!(elementTuple.element1.IsSimilarTo(elementTuple.element2)))
                    return false;
            }
            return base.IsSimilarTo(uiElement);
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            return _screenDisplayFactory.Create(
                Size, FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor,
                BackColor == Color.Default ? configuration.DefaultBackColor : BackColor, '*');
        }

    }
}
