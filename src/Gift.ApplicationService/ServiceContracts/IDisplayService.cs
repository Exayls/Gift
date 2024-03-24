using Gift.Domain.UIModel.MetaData;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IDisplayService
    {
        void NextContainer();
        void NextElementInSelectedContainer();
        void PreviousContainer();
        void PreviousElementInSelectedContainer();
        void Resize(Size bound);
        void ScrollDown();
        void ScrollUp();
        void UpdateDisplay();
    }
}
