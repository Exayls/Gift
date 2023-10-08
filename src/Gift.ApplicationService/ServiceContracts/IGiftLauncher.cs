using Gift.Domain.UIModel;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IGiftLauncher
    {
		void Initialize(string filename);
		void Initialize(GiftUI giftui);
		void Run();
    }
}
