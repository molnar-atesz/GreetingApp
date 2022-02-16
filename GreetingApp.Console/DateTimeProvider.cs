using System;

namespace GreetingApp.Terminal
{
    public class DateTimeProvider
    {
        public virtual TimeOnly Now()
        {
            return TimeOnly.FromDateTime(DateTime.Now);
        }
    }
}