using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.DB
{
    public class Seeder
    {
        public static async Task Seed(InMemoryDbContext context)
        {
            List<Rental> rentals = new()
            {
                new Rental()
                {
                    Id = 1,
                    Name = "Rowerowy popcorn krowy",
                    Location = "ul. popcornowa 34"
                },
                new Rental()
                {
                    Id = 2,
                    Name = "Rowerowy raj",
                    Location = "ul. rajska 55"
                }
            };
            List<VehicleType> vehicleTypes = new()
            {
                new VehicleType()
                {
                    Id = 1,
                    Name = "Rower"
                },
                new VehicleType()
                {
                    Id = 2,
                    Name = "Motorower"
                }
            };
            List<Vehicle> vehicles = new()
            {
                new Vehicle()
                {
                    Id = 1,
                    Name = "Quad 4 pedaly",
                    Type = new VehicleType()
                    {
                        Id = 3,
                        Name = "Quad"
                    },
                    Electric = true,
                    Price = 123,
                    VehicleTypeId = 3,
                    RentalId = 1

                },
                new Vehicle()
                {
                    Id = 2,
                    Name = "Kellys 4",
                    Type = vehicleTypes.First(),
                    Electric = true,
                    Price = 123,
                    VehicleTypeId = 2,
                    RentalId = 2

                },
            };
            await context.AddRangeAsync(rentals);
            await context.AddRangeAsync(vehicleTypes);
            await context.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

        }
    }
}

