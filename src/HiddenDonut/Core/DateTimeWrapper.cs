using System;

namespace HiddenDonut.Core
{
    internal class DateTimeWrapper : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}