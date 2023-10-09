using Gift.ApplicationService.ServiceContracts;
using System.Threading.Tasks;

namespace Gift.ApplicationService.Services
{
    public class LifeTimeService : ILifeTimeService
    {
        private TaskCompletionSource<bool> completion;

        public virtual async Task RunAsync()
        {
            await completion.Task;
        }

        public virtual void Run()
        {
            completion = new TaskCompletionSource<bool>();
            RunAsync().Wait();
        }

        public void Stop()
        {
            completion.SetResult(true);
        }
    }
}