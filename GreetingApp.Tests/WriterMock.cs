using GreetingApp.Terminal.Interfaces;
using System;

namespace GreetingApp.Tests
{
    internal class WriterMock : IWriter
    {
        public string Content { get; private set; }

        public void WriteLine(string message)
        {
            Content = $"{message}{Environment.NewLine}";
        }
    }
}