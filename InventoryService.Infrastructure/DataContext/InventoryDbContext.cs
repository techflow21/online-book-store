using InventoryService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.DataContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {}

        public DbSet<Book>Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
