using FluentAssertions;
using GreetingApp.Terminal;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xunit;

namespace GreetingApp.Tests
{
    public class GreetingServiceTest
    {
        [Fact]
        public void Greet_before_ten_say_good_morning()
        {
            var writerMock = new WriterMock();
            var timeMock = DateTimeProviderMock.MorningProvider;
            var expected = string.Format("Good morning{0}", Environment.NewLine);
            var nullLogger = NullLogger<GreetingService>.Instance;
            var sut = new GreetingService(writerMock, timeMock, nullLogger);

            sut.Greet();

            writerMock.Content.Should().Be(expected);
        }

        [Fact]
        public void Greet_after_ten_say_good_afternoon()
        {
            var writerMock = new WriterMock();
            var timeMock = DateTimeProviderMock.AfternoonProvider;
            var expected = string.Format("Good afternoon{0}", Environment.NewLine);
            var nullLogger = NullLogger<GreetingService>.Instance;
            var sut = new GreetingService(writerMock, timeMock, nullLogger);

            sut.Greet();

            writerMock.Content.Should().Be(expected);
        }
    }
}