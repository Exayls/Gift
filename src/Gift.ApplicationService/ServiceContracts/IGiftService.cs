using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.UIModel;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IGiftService
    {
		void Initialize(string filename);
		void Initialize(GiftUI giftui);
        void AddSignalHandler(ISignalHandlerService handler);
        void Run();
        void Stop();
    }
}
