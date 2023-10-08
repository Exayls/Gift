namespace Gift.ApplicationService.Services.Monitor
{
    public interface IMonitorManager
    {
        void Add(IMonitor monitor);
        void Remove(IMonitor monitor);
        void StartCheckingMonitors();
    }
}
