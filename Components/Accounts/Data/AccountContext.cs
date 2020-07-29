using Microsoft.EntityFrameworkCore;

namespace Accounts.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        public DbSet<AccountRecord> AccountRecords { get; set; }
    }
}