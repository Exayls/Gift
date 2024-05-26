using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Element;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IGiftService
    {
        void Initialize(string filename);
        void Initialize(UIElement giftui);
        void InitializeHotReload(string file);

        void AddSignalHandler(ISignalHandler handler);
        void AddMonitor(IMonitor handler);

        void Run();
        void Stop();
    }
}
