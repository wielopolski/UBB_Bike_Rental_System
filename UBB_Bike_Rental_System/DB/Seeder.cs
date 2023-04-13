using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.DB
{
    public class Seeder
    {
        public static async Task Seed(InMemoryDbContext context)
        {

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
                Name = "Quad"
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
                    VehicleTypeId = 3

                }
            };
            await context.AddRangeAsync(vehicleTypes);
            await context.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

        }
    }
}

