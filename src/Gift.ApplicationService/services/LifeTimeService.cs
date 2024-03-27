using Gift.ApplicationService.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace Gift.ApplicationService.Services
{
    public class LifeTimeService : ILifeTimeService
    {
        private TaskCompletionSource<bool> completion;

        public LifeTimeService()
        {
            completion = new TaskCompletionSource<bool>();
        }

        public virtual async Task RunAsync()
        {
            await completion.Task;
        }

        public virtual void Run()
        {
            Console.CursorVisible = false;
			Console.Clear();
            RunAsync().Wait();
        }

        public void Stop()
        {
            Console.CursorVisible = true;
            completion.SetResult(true);
        }
    }
}
