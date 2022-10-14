using System;
using System.Threading;
using System.Threading.Tasks;
using LiveImport.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LiveImport.Archiver
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // await _bus.Publish(
                //     new Vault {FileName = $"safcom-oct-{DateTime.Now.Ticks}", DateLocked = DateTime.Now},
                //     stoppingToken);
                //
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}