using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Models
{
    public class Vehicle : IEntity<int>
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("VehicleType")]
        [Required]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType Type { get; set; }
        [ForeignKey("Rental")]
        [Required]
        public int RentalId { get; set; }
        public virtual Rental Rental { get; set; }
        [Required]
        public bool Electric { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
