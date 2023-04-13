using Microsoft.EntityFrameworkCore;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.DB
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<VehicleType>VehicleType{ get; set; }
        public DbSet<Vehicle>Vehicle{ get; set; }
        public DbSet<Rental>Rental{ get; set; }
        public DbSet<Booking>Booking{ get; set; }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options):base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>().HasKey(x=>x.Id);
            modelBuilder.Entity<Vehicle>().HasKey(x=>x.Id);
            modelBuilder.Entity<Rental>().HasKey(x=>x.RentalId);
            modelBuilder.Entity<Booking>().HasKey(x=>x.BookingId);
        }
    }
}
