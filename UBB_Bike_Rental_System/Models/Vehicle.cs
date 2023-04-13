using System.ComponentModel.DataAnnotations.Schema;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Models
{
    public class Vehicle : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType Type { get; set; }
        public bool Electric { get; set; }
        public decimal Price { get; set; }
    }
}
