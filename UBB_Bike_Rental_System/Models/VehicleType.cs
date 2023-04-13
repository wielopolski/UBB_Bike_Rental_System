using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Models
{
    public class VehicleType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vechicles { get; set; }
    }
}
