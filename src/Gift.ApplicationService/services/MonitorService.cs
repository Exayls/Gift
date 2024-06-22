using System.Collections.Generic;
using System.Threading.Tasks;
using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.ServiceContracts;

namespace Gift.ApplicationService.Services
{
    public class MonitorService : IMonitorService
    {
        public IList<IMonitor> Monitors { get; private set; }

        public MonitorService()
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
                await Task.Run(CheckMonitors);
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

        public void StopCheckingMonitors()
        {
            throw new System.NotImplementedException();
        }
    }
}
