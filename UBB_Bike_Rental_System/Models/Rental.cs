using System.ComponentModel.DataAnnotations;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Models
{
    public class Rental : IEntity<int>
	{
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual ICollection<Vehicle> Vechicles { get; set; }
    }
}
