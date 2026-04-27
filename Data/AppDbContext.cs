using ilactakipsistem.Models;
using Microsoft.EntityFrameworkCore;

namespace ilactakipsistem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<DosageSchedule> DosageSchedules { get; set; }
        public DbSet<UsageLog> UsageLogs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cascade delete settings
            modelBuilder.Entity<DosageSchedule>()
                .HasOne(d => d.Medicine)
                .WithMany(m => m.DosageSchedules)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsageLog>()
                .HasOne(u => u.Medicine)
                .WithMany(m => m.UsageLogs)
                .HasForeignKey(u => u.MedicineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
