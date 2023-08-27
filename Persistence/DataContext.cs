using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<WasteReport> WasteReports { get; set; }
        public DbSet<WasteGoal> WasteGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WasteReport>()
                .HasOne(p => p.Reporter)
                .WithMany(b => b.WasteReports)
                .HasForeignKey(p => p.AppUserId)
                .IsRequired();
        }
    }
}