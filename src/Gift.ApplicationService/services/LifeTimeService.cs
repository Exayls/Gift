using Gift.ApplicationService.ServiceContracts;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Gift.ApplicationService.Services
{
    public class LifeTimeService : ILifeTimeService
    {
        private TaskCompletionSource<bool> completion;
        private readonly IHostApplicationLifetime _lifeTime;

        public LifeTimeService(IHostApplicationLifetime lifeTime)
        {
            completion = new TaskCompletionSource<bool>();
            _lifeTime = lifeTime;
        }

        public virtual async Task RunAsync()
        {
            await completion.Task;
        }

        public virtual void Run()
        {
        }

        public void Stop()
        {
            Console.CursorVisible = true;
            _lifeTime.StopApplication();
        }
    }
}
