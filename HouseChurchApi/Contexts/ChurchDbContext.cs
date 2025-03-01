using HouseChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseChurchApi.Contexts
{
    public class ChurchDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<PrayerRequest> PrayerRequests { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        public ChurchDbContext(DbContextOptions<ChurchDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>()
                .HasOne(f => f.Event)
                .WithMany(e => e.FoodItems)
                .HasForeignKey(f => f.EventId);
        }
    }
}
