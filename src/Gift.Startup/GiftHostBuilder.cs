

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Gift.Startup.Extensions;
using Gift.ApplicationService.ServiceContracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

public class GiftHostBuilder : IHostBuilder
{
    private readonly IHostBuilder _hostBuilder;
    private string? _xmlFile;

    public IDictionary<object, object> Properties => _hostBuilder.Properties;

    public GiftHostBuilder(string xml)
    {
        _hostBuilder = new HostBuilder();
    }

    public GiftHostBuilder WithXMl(string xml)
    {
        _xmlFile = xml;
        return this;
    }

    public IHost Build()
    {
        _hostBuilder.ConfigureServices(
            services =>
            {
                services.AddGiftServices();
				services.AddHostedService<GiftWorker>();
            });
        Console.WriteLine("test2");
        return _hostBuilder.Build();
    }

    private class GiftWorker : IHostedService
    {
        private readonly IGiftService _giftService;
        private readonly string? _xml;

        public GiftWorker(IGiftService giftService, IConfiguration appConf)
        {
            Console.WriteLine("test1");
            _giftService = giftService;
            _xml = appConf.GetValue<string>("GiftFile");
            Console.WriteLine(_xml);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_xml is not null)
            {
                _giftService.Initialize(_xml);
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
