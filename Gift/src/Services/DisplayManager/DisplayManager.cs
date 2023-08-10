using Gift.src.UIModel;
using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.MetaData;
using Gift.UI.Render;

namespace Gift.UI.DisplayManager
{
    public class DisplayManager : IDisplayManager
    {
        private IDisplayer _displayer;
        private IGiftUiProvider _uiProvider;
        private IRenderer _renderer;

        public DisplayManager(IDisplayer displayer, IRenderer renderer, IGiftUiProvider ui)
        {
            _displayer = displayer;
            _uiProvider = ui;
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
                _displayer.display(View);
            }
        }

        public void NextContainer()
        {
            _uiProvider.Ui.NextContainer();
        }

        public void PreviousContainer()
        {
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
