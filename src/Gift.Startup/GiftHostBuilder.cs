

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Gift.Startup.Extensions;
using Gift.ApplicationService.ServiceContracts;
using System.Threading.Tasks;

public class GiftHostBuilder : HostBuilder
{
    public GiftHostBuilder(string xml)
        : base()
    {
        this.ConfigureServices(services =>
                               {
                                   services.AddGiftServices();
                                   services.AddHostedService<GiftWorker>(serviceProvider =>
                                                                             new GiftWorker(serviceProvider.GetRequiredService<IGiftService>(), xml));
                               });
    }

    private class GiftWorker : IHostedService
    {
        private readonly IGiftService _giftService;
        private readonly string _xml;

        public GiftWorker(IGiftService giftService, string xml)
        {
            _giftService = giftService;
            _xml = xml;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _giftService.Initialize(_xml);
            _giftService.Run();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _giftService.Stop();
            return Task.CompletedTask;
        }
    }
}
