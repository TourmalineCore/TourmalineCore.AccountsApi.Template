using NodaTime.Extensions;
using NodaTime;
using System;

namespace UserManagementService.DataAccess.Respositories
{
    public class InstantTime : IClock
    {
        public Instant GetCurrentInstant()
        {
            return DateTime.UtcNow.ToInstant();
        }
    }
}
