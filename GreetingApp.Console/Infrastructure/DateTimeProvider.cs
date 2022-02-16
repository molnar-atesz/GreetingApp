namespace GreetingApp.Terminal.Infrastructure
{
    public class DateTimeProvider
    {
        public virtual TimeOnly Now()
        {
            return TimeOnly.FromDateTime(DateTime.Now);
        }
    }
}