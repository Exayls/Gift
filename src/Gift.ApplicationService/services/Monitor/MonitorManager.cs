using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift.ApplicationService.services.Monitor
{
    public class MonitorManager : IMonitorManager
    {
        public IList<IMonitor> Monitors { get; private set; }

        public MonitorManager()
        {
            Monitors = new List<IMonitor>();
        }
        public void Add(IMonitor monitor)
        {
            lock (Monitors)
            {
                Monitors.Add(monitor);
            }
        }
        public void Remove(IMonitor monitor)
        {
            lock (Monitors)
            {
                Monitors.Remove(monitor);
            }
        }

        public async void StartCheckingMonitors()
        {
            while (true)
            {
                await Task.Run(() => CheckMonitors());
            }
        }

        private void CheckMonitors()
        {
            lock (Monitors)
            {
                foreach (IMonitor monitor in Monitors)
                {
                    monitor.Check();
                }
            }
        }
    }
}
