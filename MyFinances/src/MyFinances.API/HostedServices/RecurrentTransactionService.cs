using MyFinances.API.Services;

namespace MyFinances.API.HostedServices
{
    public class RecurrentTransactionService : IHostedService, IDisposable
    {
        private readonly ILogger<RecurrentTransactionService> _logger;
        private Timer _timer = null!;

        public RecurrentTransactionService(IServiceProvider services, ILogger<RecurrentTransactionService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TimeSpan interval = TimeSpan.FromHours(24);

            //calculate time to run the first time & delay to set the timer
            //DateTime.Today gives time of midnight 00.00
            var nextRunTime = DateTime.Today.AddDays(1);
            var currentTime = DateTime.Now;
            var firstInterval = nextRunTime.Subtract(currentTime);

            Action action = () =>
            {
                var initialDelay = Task.Delay(firstInterval);
                initialDelay.Wait();

                //apply recurrences at expected time
                ApplyRecurrences(null);

                //now schedule it to be called every 24 hours for future
                _timer = new Timer(
                    ApplyRecurrences,
                    null,
                    Timeout.InfiniteTimeSpan,
                    interval
                );
            };

            // no need to await this call here because this task is scheduled to run much much later.
            Task.Run(action, cancellationToken);
            return Task.CompletedTask;
        }

        private async void ApplyRecurrences(object? state)
        {
            _logger.LogInformation("Applying recurrences");

            using (var scope = Services.CreateScope())
            {
                var recurrenceService =
                    scope.ServiceProvider
                        .GetRequiredService<IRecurrenceService>();

                await recurrenceService.ApplyRecurrences();
            }

            _logger.LogInformation("Recurrences applied");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
