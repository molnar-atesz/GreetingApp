using FluentAssertions;
using GreetingApp.Terminal;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xunit;

namespace GreetingApp.Tests.Integration
{
    public class GreetControllerTest
    {
        [Fact]
        public void Run_greet_in_the_morning()
        {
            string expected = $"Good morning{Environment.NewLine}";
            var writerMock = new WriterMock();
            var timeMock = DateTimeProviderMock.MorningProvider;
            var nullLogger = NullLogger<GreetController>.Instance;
            var greetService = new GreetingService();
            var sut = new GreetController(greetService,
                                        writerMock,
                                        timeMock,
                                        nullLogger);

            sut.Run();

            writerMock.Content.Should().Be(expected);
        }

        [Fact]
        public void Run_greet_in_the_afternoon()
        {
            string expected = $"Good afternoon{Environment.NewLine}";
            var writerMock = new WriterMock();
            var timeMock = DateTimeProviderMock.AfternoonProvider;
            var nullLogger = NullLogger<GreetController>.Instance;
            var greetService = new GreetingService();
            var sut = new GreetController(greetService,
                                        writerMock,
                                        timeMock,
                                        nullLogger);

            sut.Run();

            writerMock.Content.Should().Be(expected);
        }
    }
}
