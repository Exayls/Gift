﻿using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using System;
using System.Collections.Generic;

namespace Gift.Domain.UIModel
{
    public class GiftUI : Container
    {

        public override int Height
        {
            get { return Bound.Height; }
        }
        public override int Width
        {
            get { return Bound.Width; }
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

        public GiftUI(Bound bound, IBorder border) : base(new ScreenDisplayFactory(), bound, border)
        {
            SelectableContainers = new List<Container>();
        }

        public GiftUI(Bound bound) : this(bound, new NoBorder())
        {
        }

        public GiftUI() : base()
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
            return _screenDisplayFactory.Create(Bound, FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor, BackColor == Color.Default ? configuration.DefaultBackColor : BackColor, '*');
        }

        public override Position GetRelativePosition(Context context)
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