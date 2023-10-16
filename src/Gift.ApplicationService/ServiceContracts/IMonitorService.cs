using Gift.Domain.ServiceContracts;

namespace Gift.ApplicationService.ServiceContracts
{
    public interface IMonitorService
    {
        void Add(IMonitor monitor);
        void Remove(IMonitor monitor);
        void StartCheckingMonitors();
        void StopCheckingMonitors();
    }
}
