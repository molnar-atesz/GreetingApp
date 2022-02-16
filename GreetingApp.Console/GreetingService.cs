using Microsoft.Extensions.Logging;

namespace GreetingApp.Terminal
{
    public class GreetingService
    {
        private readonly IWriter _sw;
        private readonly DateTimeProvider _dateTimeProvider;
        private readonly ILogger<GreetingService> _logger;

        private bool IsAfternoon => _dateTimeProvider.Now() > new TimeOnly(10, 0);

        public GreetingService(ILogger<GreetingService> logger)
        {
            _sw = new ConsoleWriter();
            _dateTimeProvider = new DateTimeProvider();
            _logger = logger;
        }

        public GreetingService(IWriter sw,
                                DateTimeProvider dateTimeProvider,
                                ILogger<GreetingService> logger)
        {
            _sw = sw;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public void Greet()
        {
            var message = IsAfternoon ? "Good afternoon" : "Good morning";
            _logger.LogInformation($"Greet called with: {message}");
            _sw.WriteLine(message);
        }
    }
}