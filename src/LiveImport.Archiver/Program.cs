using System;
using LiveImport.Archiver;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = 
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.Configure<BusSettings>(configuration.GetSection(BusSettings.Key));
        var busSettings = configuration.GetSection(BusSettings.Key).Get<BusSettings>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<VaultConsumer>();
            x.UsingRabbitMq((context,cfg) =>
            {
                cfg.Host(busSettings.Host, busSettings.Vhost, h => {
                    h.Username(busSettings.User);
                    h.Password(busSettings.Pass);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
      
        services.AddHostedService<Worker>(); 
        
    })
    .Build();

await host.RunAsync();