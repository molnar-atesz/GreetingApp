using GreetingApp.Terminal.Infrastructure;
using GreetingApp.Terminal.Interfaces;

namespace GreetingApp.Terminal
{
    public class GreetingService
    {
        public string Greet(TimeOnly timeOnly)
        {
            return timeOnly < new TimeOnly(10, 0) ? "Good morning" : "Good afternoon";
        }
    }
}