using System.Collections.Generic;
using System.Linq;
using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.ApplicationService.Services
{
    public class DisplayService : IDisplayService
    {
        private IDisplayer _displayer;
        private IGiftUiProvider _uiProvider;
        private IRepository _repository;
        private IRenderer _renderer;

        public DisplayService(IDisplayer displayer, IRenderer renderer, IGiftUiProvider uiProvider,
                              IRepository repository)
        {

            _displayer = displayer;
            _uiProvider = uiProvider;
            _repository = repository;
            _renderer = renderer;
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
            }
        }

        public void NextElementInSelectedContainer()
        {
			_repository.GetSelectedContainer()?.NextElement();
        }

        public void PreviousElementInSelectedContainer()
        {
			_repository.GetSelectedContainer()?.PreviousElement();
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
