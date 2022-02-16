using GreetingApp.Terminal.Interfaces;

namespace GreetingApp.Terminal.Infrastructure
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}