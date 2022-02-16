using GreetingApp.Terminal;
using System;

namespace GreetingApp.Tests
{
    internal class DateTimeProviderMock : DateTimeProvider
    {
        private readonly TimeOnly _now;
        private DateTimeProviderMock(TimeOnly now)
        {
            _now = now; ;
        }

        public static DateTimeProviderMock MorningProvider => new DateTimeProviderMock(new TimeOnly(9, 0));
        public static DateTimeProviderMock AfternoonProvider => new DateTimeProviderMock(new TimeOnly(13, 0));

        public override TimeOnly Now()
        {
            return _now;
        }
    }
}