﻿using System.Collections.Generic;
using System.Linq;
using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Microsoft.Extensions.Logging;

namespace Gift.ApplicationService.Services
{
    public class DisplayService : IDisplayService
    {
        private readonly IDisplayer _displayer;
        private readonly IRepository _repository;
        private readonly IRenderer _renderer;
        private readonly ILogger<IDisplayService> _logger;

        public DisplayService(IDisplayer displayer,
                              IRenderer renderer,
                              IRepository repository,
                              ILogger<IDisplayService> logger)
        {

            _displayer = displayer;
            _repository = repository;
            _renderer = renderer;
            _logger = logger;
        }

        public void UpdateDisplay()
        {
            _logger.LogTrace("UpdateDisplay");
            IScreenDisplay view = CreateView();
            PrintFrame(view);
        }

        public IScreenDisplay CreateView()
        {
            _logger.LogTrace("CreateView");
            UIElement ui = _repository.GetRoot();
            IScreenDisplay View = _renderer.GetRenderDisplay(ui);
            return View;
        }

        private void PrintFrame(IScreenDisplay? View)
        {
            _logger.LogTrace("PrintFrame");
            if (View != null)
            {
                _displayer.Display(View);
            }
        }

        public void NextContainer()
        {
            _logger.LogTrace("NextContainer");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer == null)
            {
                _logger.LogDebug("NextContainer: No selected container");
                return;
            }
            List<Container> selectableContainers = _repository.GetSelectableContainers().ToList();
            var container = selectableContainers[(selectableContainers.IndexOf(selectedContainer) + 1) %
                                                 selectableContainers.Count];
            _repository.SelectContainer(container);
            _logger.LogDebug("select container {Container}", container);
        }

        public void PreviousContainer()
        {
            _logger.LogTrace("PreviousContainer");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer == null)
            {
                _logger.LogDebug("PreviousContainer: No selected container");
                return;
            }
            List<Container> selectableContainers = _repository.GetSelectableContainers().ToList();
            var container = selectableContainers[(selectableContainers.IndexOf(selectedContainer) - 1 +
                                                  selectableContainers.Count) %
                                                 selectableContainers.Count];
            _repository.SelectContainer(container);
            _logger.LogDebug("select container {Container}", container);
        }

        public void NextElementInSelectedContainer()
        {
            _logger.LogTrace("NextElement");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer is null)
            {
                _logger.LogDebug("NextElement: No selected container");
                return;
            }
            selectedContainer.NextElement();
        }

        public void PreviousElementInSelectedContainer()
        {
            _logger.LogTrace("PreviousElement");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer is null)
            {
                _logger.LogDebug("PreviousElement: No selected container");
                return;
            }
            selectedContainer.PreviousElement();
        }

        public void Resize(Size bound)
        {
            _logger.LogTrace("Resize");
            var root = _repository.GetRoot();
            if (root is Container container)
            {
                container.Resize(bound);
            }
        }

        public void ScrollUp()
        {
            _logger.LogTrace("ScrollUp");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer is null)
            {
                _logger.LogDebug("ScrollUp: No selected container");
                return;
            }
            selectedContainer.ScrollUp();
        }

        public void ScrollDown()
        {
            _logger.LogTrace("ScrollDown");
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer is null)
            {
                _logger.LogDebug("ScrollDown: No selected container");
                return;
            }
            selectedContainer.ScrollDown();
        }
    }
}
