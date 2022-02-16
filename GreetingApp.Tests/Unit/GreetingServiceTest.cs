using FluentAssertions;
using GreetingApp.Terminal;
using System;
using Xunit;

namespace GreetingApp.Tests
{
    public class GreetingServiceTest
    {
        [Fact]
        public void Greet_before_ten_say_good_morning()
        {
            var expected = "Good morning";
            var sut = new GreetingService();

            string result = sut.Greet(new TimeOnly(9, 0));

            result.Should().Be(expected);
        }

        [Fact]
        public void Greet_after_ten_say_good_afternoon()
        {
            var expected = "Good afternoon";
            var sut = new GreetingService();

            string result = sut.Greet(new TimeOnly(16, 0));

            result.Should().Be(expected);
        }
    }
}