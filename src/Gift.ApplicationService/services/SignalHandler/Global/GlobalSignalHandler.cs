using System.Threading.Tasks;

namespace Gift.ApplicationService.Services.SignalHandler.Global
{
    public class GlobalSignalHandler : IGlobalSignalHandler
    {
        public TaskCompletionSource<bool> Completion { get; set; }

        public GlobalSignalHandler()
        {
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
            Completion.SetResult(true);
        }
    }
}
