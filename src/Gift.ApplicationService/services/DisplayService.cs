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
            IScreenDisplay view = CreateView();
            PrintFrame(view);
        }

        public IScreenDisplay CreateView()
        {
            UIElement ui = _repository.GetRoot();
            IScreenDisplay View = _renderer.GetRenderDisplay(ui);
            return View;
        }

        private void PrintFrame(IScreenDisplay? View)
        {
            if (View != null)
            {
                _displayer.Display(View);
            }
        }

        public void NextContainer()
        {
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer != null)
            {
                List<Container> selectableContainers = _repository.GetSelectableContainers().ToList();
                var container = selectableContainers[(selectableContainers.IndexOf(selectedContainer) + 1) %
                                                     selectableContainers.Count];
                _repository.SelectContainer(container);
                _logger.LogDebug($"select container {container}");
            }
        }

        public void PreviousContainer()
        {
            var selectedContainer = _repository.GetSelectedContainer();
            if (selectedContainer != null)
            {
                List<Container> selectableContainers = _repository.GetSelectableContainers().ToList();
                var container = selectableContainers[(selectableContainers.IndexOf(selectedContainer) - 1 +
                                                      selectableContainers.Count) %
                                                     selectableContainers.Count];
                _repository.SelectContainer(container);
                _logger.LogDebug($"select container {container}");
            }
        }

        public void NextElementInSelectedContainer()
        {
            var selectedContainer = _repository.GetSelectedContainer();
			if(selectedContainer is null){
				_logger.LogDebug("NextElement: No selected container");
				return;
			}
			selectedContainer.NextElement();
        }

        public void PreviousElementInSelectedContainer()
        {
            var selectedContainer = _repository.GetSelectedContainer();
			if(selectedContainer is null){
				_logger.LogDebug("PreviousElement: No selected container");
				return;
			}
			selectedContainer.PreviousElement();
        }

        public void Resize(Size bound)
        {
            var root = _repository.GetRoot();
            if (root is Container)
            {
                var container = (Container)root;
                container.Resize(bound);
            }
        }

        public void ScrollUp()
        {
            _repository.GetSelectedContainer()?.ScrollUp();
        }

        public void ScrollDown()
        {
            _repository.GetSelectedContainer()?.ScrollDown();
        }
    }
}
