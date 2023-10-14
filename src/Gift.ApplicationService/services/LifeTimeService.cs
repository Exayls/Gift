using Gift.ApplicationService.ServiceContracts;
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
            RunAsync().Wait();
        }

        public void Stop()
        {
            completion.SetResult(true);
        }
    }
}
