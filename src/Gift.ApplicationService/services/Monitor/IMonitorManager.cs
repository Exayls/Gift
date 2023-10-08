namespace Gift.ApplicationService.services.Monitor
{
    public interface IMonitorManager
    {
        void Add(IMonitor monitor);
        void Remove(IMonitor monitor);
        void StartCheckingMonitors();
    }
}