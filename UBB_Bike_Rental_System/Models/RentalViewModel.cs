using Microsoft.AspNetCore.Mvc.Rendering;

namespace UBB_Bike_Rental_System.Models
{
	public class RentalViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}