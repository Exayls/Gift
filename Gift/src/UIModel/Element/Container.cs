﻿using Gift.UI.Border;
using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public abstract class Container : UIElement, IContainer
    {
        public Bound Bound { get; protected set; }
        public IList<IUIElement> Childs { get; protected set; }
        public List<IUIElement> SelectableElements { get; set; }

        private IUIElement? selectedElement;
        public IUIElement? SelectedElement
        {
            get => selectedElement; set
            {
                selectedElement = value;

                foreach (IUIElement element in SelectableElements)
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
            set
            {
                isSelectedContainer = value;
            }
        }

        protected readonly IScreenDisplayFactory _screenDisplayFactory;

        public Container(IScreenDisplayFactory screenDisplayFactory, Bound bound, IBorder border) : base(border)
        {
            Bound = bound;
            Childs = new List<IUIElement>();
            _screenDisplayFactory = screenDisplayFactory;
            SelectableElements = new List<IUIElement>();
        }
        public Container()
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                Bound = new Bound(Console.WindowHeight, Console.WindowWidth);

            }
            else
            {
                Bound = new Bound(0, 0);
            }
            Childs = new List<IUIElement>();
            _screenDisplayFactory = new ScreenDisplayFactory();
            SelectableElements = new List<IUIElement>();
        }

        public abstract Context GetContextRenderable(IRenderable renderable, Context context);

        public abstract Context GetContextRelativeRenderable(IRenderable renderable, Context context);

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
            Color frontColor = FrontColor ?? configuration.DefaultFrontColor;
            Color backColor = BackColor ?? configuration.DefaultBackColor;
            if (IsSelectedContainer)
            {
                frontColor = configuration.SelectedContainerFrontColor ?? frontColor;
                backColor = configuration.SelectedContainerBackColor ?? backColor;
            }
            IScreenDisplay screenDisplay = Border.GetDisplay(bound, frontColor, backColor);
            return screenDisplay;
        }

        public void NextElement()
        {
            if (SelectedElement != null)
            {
                SelectedElement = SelectableElements[(SelectableElements.IndexOf(SelectedElement) + 1) % SelectableElements.Count];
            }
        }

        public void PreviousElement()
        {
            if (SelectedElement != null)
            {
                SelectedElement = SelectableElements[(SelectableElements.IndexOf(SelectedElement) - 1 + SelectableElements.Count) % SelectableElements.Count];
            }
        }

    }
}