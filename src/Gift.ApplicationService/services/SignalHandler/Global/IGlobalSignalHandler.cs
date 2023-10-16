using System.Threading.Tasks;

namespace Gift.ApplicationService.Services.SignalHandler.Global
{
    public interface IGlobalSignalHandler : ISignalHandlerService
    {
        TaskCompletionSource<bool> Completion { get; set; }
    }
}
