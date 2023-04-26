﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.Event
{
    public class MonitorManager : IMonitorManager
    {
        private Timer timer;
        public IList<IMonitor> Monitors { get; private set; }

        public MonitorManager()
        {
            Monitors = new List<IMonitor>();
            timer = new Timer(CheckMonitors, null, 0, 100);
        }
        public void Add(IMonitor monitor)
        {
            Monitors.Add(monitor);
        }
        public void Remove(IMonitor monitor)
        {
            Monitors.Remove(monitor);
        }

        private void CheckMonitors(object? state)
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
