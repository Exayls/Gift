using Microsoft.Extensions.Hosting;

namespace Gift.ApplicationService.Services.SignalHandler.Global
{
    public class GlobalSignalHandler : IGlobalSignalHandler
    {
        private IHostApplicationLifetime _lifeTimeService;

        public GlobalSignalHandler(IHostApplicationLifetime lifeTime)
        {
            _lifeTimeService = lifeTime;
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
            _lifeTimeService.StopApplication();
        }
    }
}
