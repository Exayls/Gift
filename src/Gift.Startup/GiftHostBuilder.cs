using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Gift.Startup.Extensions;
using Gift.ApplicationService.ServiceContracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.ServiceContracts;

public class GiftHostBuilder : IHostBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public IDictionary<object, object> Properties => _hostBuilder.Properties;

    public GiftHostBuilder()
    {
        _hostBuilder = new HostBuilder();
    }

    public IHost Build()
    {
        _hostBuilder.ConfigureServices(
            services =>
            {
                services.AddGiftServices();
                services.AddHostedService<GiftWorker>();
            });
        return _hostBuilder.Build();
    }

    private class GiftWorker : IHostedService
    {
        private readonly IGiftService _giftService;
        private readonly string? _xml;
        private readonly bool _hotReload;
        private readonly ILogger<GiftWorker> _logger;
        private readonly IEnumerable<ISignalHandler> _signalHandlers;
        private readonly IEnumerable<IMonitor> _monitors;

        public GiftWorker(IGiftService giftService, IConfiguration appConf, ILogger<GiftWorker> logger, IEnumerable<ISignalHandler> signalHandlers, IEnumerable<IMonitor> monitors)
        {
            _giftService = giftService;
            _xml = appConf.GetValue<string>("GiftFile");
            _hotReload = appConf.GetValue<bool>("HotReloading");
            _logger = logger;
            _signalHandlers = signalHandlers;
            _monitors = monitors;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_xml is not null)
            {
                if (_hotReload == true)
                {
                    _giftService.InitializeHotReload(_xml);
                }
                else
                {
                    _giftService.Initialize(_xml);
                }
            }
            _logger.LogTrace($"There is {_signalHandlers.Count()} signalHandlers:");
            foreach (ISignalHandler sh in _signalHandlers)
            {
                _logger.LogTrace($"{sh}");
                _giftService.AddSignalHandler(sh);
            }
            _logger.LogTrace($"There is {_monitors.Count()} monitors:");
            foreach (IMonitor m in _monitors)
            {
                _logger.LogTrace($"{m}");
                _giftService.AddMonitor(m);
            }
            _giftService.Run();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _giftService.Stop();
            return Task.CompletedTask;
        }
    }

    public GiftHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
    {
        _hostBuilder.ConfigureHostConfiguration(configureDelegate);
        return this;
    }

    public GiftHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
    {
        _hostBuilder.ConfigureAppConfiguration(configureDelegate);
        return this;
    }

    public GiftHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
    {
        _hostBuilder.ConfigureServices(configureDelegate);
        return this;
    }

    public GiftHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory)
        where TContainerBuilder : notnull
    {
        _hostBuilder.UseServiceProviderFactory(factory);
        return this;
    }

    public GiftHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory)
        where TContainerBuilder : notnull
    {
        _hostBuilder.UseServiceProviderFactory(factory);
        return this;
    }

    public GiftHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
    {
        _hostBuilder.ConfigureContainer(configureDelegate);
        return this;
    }

    IHostBuilder IHostBuilder.ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate) => ConfigureHostConfiguration(configureDelegate);

    IHostBuilder IHostBuilder.ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate) => ConfigureAppConfiguration(configureDelegate);

    IHostBuilder IHostBuilder.ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate) => ConfigureServices(configureDelegate);

    IHostBuilder IHostBuilder.UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory) => UseServiceProviderFactory<TContainerBuilder>(factory);

    IHostBuilder IHostBuilder.UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory) => UseServiceProviderFactory<TContainerBuilder>(factory);

    IHostBuilder IHostBuilder.ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate) => ConfigureContainer<TContainerBuilder>(configureDelegate);

}
