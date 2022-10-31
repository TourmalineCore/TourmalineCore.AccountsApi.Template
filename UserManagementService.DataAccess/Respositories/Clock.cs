using NodaTime;
using System;

namespace UserManagementService.DataAccess.Respositories
{
    public class Clock : IClock
    {
        public Instant GetCurrentInstant()
        {
            return Instant.FromDateTimeUtc(DateTime.UtcNow);
        }
    }
}
