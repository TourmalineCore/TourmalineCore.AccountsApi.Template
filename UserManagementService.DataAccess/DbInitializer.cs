namespace UserManagementService.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(UsersDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
