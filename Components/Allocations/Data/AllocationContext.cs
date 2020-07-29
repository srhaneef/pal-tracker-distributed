using Microsoft.EntityFrameworkCore;

namespace Allocations.Data
{
    public class AllocationContext : DbContext
    {
        public AllocationContext(DbContextOptions<AllocationContext> options) : base(options)
        {
        }

        public DbSet<AllocationRecord> AllocationRecords { get; set; }
    }
}