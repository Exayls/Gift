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
            IScreenDisplay View = _renderer.GetRenderDisplay(_uiProvider.Ui);
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
            _uiProvider.Ui.NextContainer();
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
            }
            _uiProvider.Ui.PreviousContainer();
        }

        public void NextElementInSelectedContainer()
        {
            _uiProvider.Ui.NextElementInSelectedContainer();
        }

        public void PreviousElementInSelectedContainer()
        {
            _uiProvider.Ui.PreviousElementInSelectedContainer();
        }

        public void Resize(Bound bound)
        {
            _uiProvider.Ui.Resize(bound);
        }

        public void ScrollUp()
        {
            _uiProvider.Ui.SelectedContainer?.ScrollUp();
        }

        public void ScrollDown()
        {
            _uiProvider.Ui.SelectedContainer?.ScrollDown();
        }
    }
}
