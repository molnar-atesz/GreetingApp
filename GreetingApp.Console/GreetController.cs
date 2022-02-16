using GreetingApp.Terminal.Infrastructure;
using GreetingApp.Terminal.Interfaces;
using Microsoft.Extensions.Logging;

namespace GreetingApp.Terminal
{
    public class GreetController
    {
        private readonly GreetingService _greetService;
        private readonly IWriter _writer;
        private readonly DateTimeProvider _dateTimeProvider;
        private readonly ILogger<GreetController> _logger;

        public GreetController(GreetingService greetService,
                                IWriter writer,
                                DateTimeProvider dateTimeProvider,
                                ILogger<GreetController> logger)
        {
            _greetService = greetService;
            _writer = writer;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public void Run()
        {
            var greeting = _greetService.Greet(_dateTimeProvider.Now());
            _logger.LogInformation("Greeting with {message}", greeting);
            _writer.WriteLine(greeting);
        }
    }
}
