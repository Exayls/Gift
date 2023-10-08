using System.Threading.Tasks;

namespace Gift.ApplicationService.Services.SignalHandler.Global
{
    public interface IGlobalSignalHandler : ISignalHandler
    {
        TaskCompletionSource<bool> Completion { get; set; }
    }
}
