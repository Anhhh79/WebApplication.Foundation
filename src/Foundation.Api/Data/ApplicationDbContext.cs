using Foundation.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SampleItem> SampleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Áp dụng cấu hình cho entity SampleItem
            modelBuilder.ApplyConfiguration(new Configurations.SampleItemConfiguration());
        }

    }
}
