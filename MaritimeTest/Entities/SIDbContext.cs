using Microsoft.EntityFrameworkCore;

namespace MaritimeTest.Entities {
    public class SIDbContext : DbContext {

        public SIDbContext(DbContextOptions<SIDbContext> options) : base(options) {
        }
        public DbSet<Range> Ranges { get; set; }
    }
}