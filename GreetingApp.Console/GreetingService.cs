namespace GreetingApp.Terminal
{
    public class GreetingService
    {
        private readonly IWriter _sw;
        private readonly DateTimeProvider _dateTimeProvider;
        private bool IsAfternoon => _dateTimeProvider.Now() > new TimeOnly(10, 0);

        public GreetingService()
        {
            _sw = (IWriter)Console.Out;
            _dateTimeProvider = new DateTimeProvider();
        }

        public GreetingService(IWriter sw, DateTimeProvider dateTimeProvider)
        {
            _sw = sw;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Greet()
        {
            var message = IsAfternoon ? "Good afternoon" : "Good morning";
            _sw.WriteLine(message);
        }
    }
}