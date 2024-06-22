using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using System.Collections.Generic;
using System.Linq;

namespace Gift.Domain.UIModel.Element
{
    public abstract class Container : UIElement
    {
        public Size Size { get; protected set; }
        public int ScrollIndex { get; protected set; }
        public IList<UIElement> Childs { get; protected set; }
        public IList<UIElement> SelectableElements { get; protected set; }
        public bool IsSelectableContainer { get; }

        private UIElement? selectedElement;
        public UIElement? SelectedElement
        {
            get => selectedElement;
            set
            {
                selectedElement = value;

                foreach (UIElement element in SelectableElements)
                {
                    element.IsSelectedElement = false;
                }
                if (SelectedElement != null)
                {
                    SelectedElement.IsSelectedElement = true;
                }
            }
        }

        public bool IsSelectedContainer { get; set; }


        public Container(Size bound, IBorder border, Color frontColor,
                         Color backColor, bool isSelectableContainer, string id)
            : base(border, frontColor: frontColor, backColor: backColor, id: id)
        {
            Size = bound;
            Childs = new List<UIElement>();
            SelectableElements = new List<UIElement>();
            IsSelectableContainer = isSelectableContainer;
        }

        public abstract Position GetContext(IRenderable renderable, Position position);

        public override IScreenDisplay GetDisplayBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            var screenDisplayBuilder = new ScreenDisplayBuilder();
            Color frontColor = colorResolver.GetFrontColor(this, configuration);
            Color backColor = colorResolver.GetBackColor(this, configuration);
            Size trueSize = sizeCalculator.GetTrueSize(this);
            screenDisplayBuilder.WithFrontColor(frontColor).WithBackColor(backColor).WithBound(trueSize);
            IScreenDisplay screenDisplay = Border.GetDisplay(screenDisplayBuilder);
            return screenDisplay;
        }

        public void NextElement()
        {
            if (SelectedElement != null)
            {
                SelectedElement =
                    SelectableElements[(SelectableElements.IndexOf(SelectedElement) + 1) % SelectableElements.Count];
            }
        }

        public void PreviousElement()
        {
            if (SelectedElement != null)
            {
                SelectedElement =
                    SelectableElements[(SelectableElements.IndexOf(SelectedElement) - 1 + SelectableElements.Count) %
                                       SelectableElements.Count];
            }
        }

        public void ScrollDown()
        {
            ScrollIndex += 1;
        }

        public void ScrollUp()
        {
            ScrollIndex -= 1;
        }

        public void Add(UIElement uIElement)
        {
            Childs.Add(uIElement);
        }

        public void AddSelectableChild(UIElement uIElement)
        {
            if (!Childs.Contains(uIElement))
            {
                Childs.Add(uIElement);
            }
            if (!SelectableElements.Contains(uIElement))
            {
                SelectableElements.Add(uIElement);
            }
            SelectedElement ??= uIElement;
        }

        public override bool IsSimilarTo(UIElement element)
        {
            if (!base.IsSimilarTo(element))
                return false;
            if (element is not Container)
                return false;
            Container container = (Container)element;
            if (!Size.Equals(container.Size))
                return false;

            if (Childs.Count != container.Childs.Count)
                return false;
            foreach ((UIElement element1, UIElement element2) in Childs.Zip(container.Childs))
            {
                if (!element1.IsSimilarTo(element2))
                    return false;
            }
            if (SelectableElements.Count != container.SelectableElements.Count)
                return false;
            foreach ((UIElement element1,
                      UIElement element2) in SelectableElements.Zip(container.SelectableElements))
            {
                if (!element1.IsSimilarTo(element2))
                    return false;
            }
            return true;
        }

        public void Resize(Size bound)
        {
            Size = bound;
        }
    }
}
