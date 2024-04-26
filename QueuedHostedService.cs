using Microsoft.Identity.Web;

namespace DataHive.Enterprises.Core.Services
{
    public class QueuedHostedService : BackgroundService
    {
        ITokenAcquisition _tokenAcquisition;
        public QueuedHostedService(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            var token = await _tokenAcquisition.GetAccessTokenForAppAsync("api://0f5ff0f2-5a7f-430e-8ea1-6e133055990e/.default");
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Executing...");
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            // "Queued Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
