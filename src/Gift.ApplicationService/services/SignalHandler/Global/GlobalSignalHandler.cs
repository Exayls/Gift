using Gift.ApplicationService.ServiceContracts;
using System.Threading.Tasks;

namespace Gift.ApplicationService.Services.SignalHandler.Global
{
    public class GlobalSignalHandler : IGlobalSignalHandler
    {
        private ILifeTimeService _lifeTimeService;

        public TaskCompletionSource<bool> Completion { get; set; }

        public GlobalSignalHandler(ILifeTimeService launcherService)
        {
            _lifeTimeService = launcherService;
            Completion = new TaskCompletionSource<bool>();
        }


        public void HandleSignal(ISignal signal)
        {
            switch (signal.Name)
            {
                case "Global.Quit":
                    QuitApp();
                    break;
                default:
                    break;
            }
        }

        private void QuitApp()
        {
            _lifeTimeService.Stop();
        }
    }
}
