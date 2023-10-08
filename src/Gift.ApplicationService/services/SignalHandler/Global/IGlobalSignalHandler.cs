using System.Threading.Tasks;

namespace Gift.ApplicationService.services.SignalHandler.Global
{
    public interface IGlobalSignalHandler : ISignalHandler
    {
        TaskCompletionSource<bool> Completion { get; set; }
    }
}
