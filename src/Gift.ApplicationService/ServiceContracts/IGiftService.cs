using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.UIModel.Element;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IGiftService
    {
        void Initialize(string filename);
        void Initialize(UIElement giftui);
        void AddSignalHandler(ISignalHandlerService handler);
        void InitializeHotReload(string file);
        void Run();
        void Stop();
    }
}
