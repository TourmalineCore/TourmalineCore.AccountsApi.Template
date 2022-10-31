using NodaTime;
using System;

namespace UserManagementService.Application.Services
{
    public class Clock : IClock
    {
        public Instant GetCurrentInstant()
        {
            return Instant.FromDateTimeUtc(DateTime.UtcNow);
        }
    }
}
