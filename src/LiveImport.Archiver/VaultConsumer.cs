using System.Threading.Tasks;
using LiveImport.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace LiveImport.Archiver
{
    public class VaultConsumer:IConsumer<Vault>
    {
        private readonly ILogger<VaultConsumer> _logger;

        public VaultConsumer(ILogger<VaultConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Vault> context)
        {
            _logger.LogInformation($"Recieved Message: Archiving File {context.Message.FileName} on {context.Message.DateLocked:f} ");
            return Task.CompletedTask;
        }
    }
}