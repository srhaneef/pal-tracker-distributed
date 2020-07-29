using Microsoft.EntityFrameworkCore;

namespace Users.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        
        public DbSet<UserRecord> UserRecords { get; set; }
    }
}