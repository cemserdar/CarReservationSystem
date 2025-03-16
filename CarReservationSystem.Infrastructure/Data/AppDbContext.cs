using CarReservationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarReservationSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}