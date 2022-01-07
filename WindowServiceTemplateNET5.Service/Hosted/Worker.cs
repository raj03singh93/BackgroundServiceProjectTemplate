using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WindowServiceTemplateNET5.Service.Hosted
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IServiceScopeFactory serviceScope;
        private bool disposed = false;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScope)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.serviceScope = serviceScope ?? throw new ArgumentNullException(nameof(serviceScope));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    // To call scoped services
                    using (var scope = serviceScope.CreateScope())
                    {
                        // var service = scope.ServiceProvider.GetRequiredService<IYourService>();
                        await Task.Delay(1000, stoppingToken);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            logger.LogInformation($"Is disposed: {disposed}");
            if (disposed)
            {
                return;
            }
            logger.LogInformation("Disposing object");
            disposed = true;
            logger.LogInformation($"Is disposed: {disposed}");
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
