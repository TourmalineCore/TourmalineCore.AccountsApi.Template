using NodaTime;
using System;

namespace UserManagementService.Application.Users.Commands
{
    public class Clock : IClock
    {
        public Instant GetCurrentInstant()
        {
            return Instant.FromDateTimeUtc(DateTime.UtcNow);
        }
    }
}
