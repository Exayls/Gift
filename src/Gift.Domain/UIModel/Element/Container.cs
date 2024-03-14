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
        public Bound Bound { get; protected set; }
        public int ScrollIndex { get; protected set; }
        public IList<UIElement> Childs { get; protected set; }
        public IList<UIElement> SelectableElements { get; protected set; }
        public bool IsSelectableContainer { get; }

        private UIElement? selectedElement;
        public UIElement? SelectedElement
        {
            get => selectedElement;
            set {
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

        private bool isSelectedContainer;
        public bool IsSelectedContainer
        {
            get => isSelectedContainer;
            set {
                isSelectedContainer = value;
            }
        }

        protected readonly IScreenDisplayFactory _screenDisplayFactory;

        public Container(IScreenDisplayFactory screenDisplayFactory, Bound bound, IBorder border, Color frontColor,
                         Color backColor, bool isSelectableContainer)
            : base(border, frontColor: frontColor, backColor: backColor)
        {
            Bound = bound;
            Childs = new List<UIElement>();
            _screenDisplayFactory = screenDisplayFactory;
            SelectableElements = new List<UIElement>();
            IsSelectableContainer = isSelectableContainer;
        }

        public abstract Context GetContextRelativeRenderable(Renderable renderable, Context context);

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration, IColorResolver colorResolver)
        {
			var screenDisplayBuilder = new ScreenDisplayBuilder();
			Color frontColor = colorResolver.GetFrontColor(this, configuration);
			Color backColor = colorResolver.GetBackColor(this, configuration);
			screenDisplayBuilder.WithFrontColor(frontColor).WithBackColor(backColor).WithBound(bound);
            IScreenDisplay screenDisplay = Border.GetDisplay(screenDisplayBuilder);
            return screenDisplay;
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
			var screenDisplayBuilder = new ScreenDisplayBuilder();
            Color frontColor = FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor;
            Color backColor = BackColor == Color.Default ? configuration.DefaultBackColor : BackColor;
            if (IsSelectedContainer)
            {
                frontColor = configuration.SelectedContainerFrontColor == Color.Default
                                 ? frontColor
                                 : configuration.SelectedContainerFrontColor;
                backColor = configuration.SelectedContainerBackColor == Color.Default
                                ? backColor
                                : configuration.SelectedContainerBackColor;
            }
			screenDisplayBuilder.WithFrontColor(frontColor).WithBackColor(backColor).WithBound(bound);
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
            this.ScrollIndex += 1;
        }

        public void ScrollUp()
        {
            this.ScrollIndex -= 1;
        }

        public void AddUnselectableChild(UIElement uIElement)
        {
            Childs.Add(uIElement);
        }

        public void AddSelectableChild(UIElement uIElement)
        {
            if (!Childs.Contains(uIElement))
            {
                Childs.Add(uIElement);
            }
            SelectableElements.Add(uIElement);
            if (SelectedElement == null)
            {
                SelectedElement = uIElement;
            }
        }

        public override bool IsSimilarTo(UIElement uiElement)
        {
            if (!(base.IsSimilarTo(uiElement)))
                return false;
            if (!(uiElement is Container))
                return false;
            Container element = (Container)uiElement;
            if (!Bound.Equals(element.Bound))
                return false;

            if (Childs.Count != element.Childs.Count)
                return false;
            foreach ((UIElement element1, UIElement element2)elementTuple in Childs.Zip(element.Childs))
            {
                if (!(elementTuple.element1.IsSimilarTo(elementTuple.element2)))
                    return false;
            }
            if (SelectableElements.Count != element.SelectableElements.Count)
                return false;
            foreach ((UIElement element1,
                      UIElement element2)elementTuple in SelectableElements.Zip(element.SelectableElements))
            {
                if (!(elementTuple.element1.IsSimilarTo(elementTuple.element2)))
                    return false;
            }
            return true;
        }
    }
}
