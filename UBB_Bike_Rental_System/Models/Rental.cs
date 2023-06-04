using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Models
{
    public class Rental : IEntity<int>
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Vehicle> Vechicles { get; set; }
    }
}
